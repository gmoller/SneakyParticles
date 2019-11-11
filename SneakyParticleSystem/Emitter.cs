namespace SneakyParticleSystem
{
    public class Emitter
    {
        private readonly IRandom _randomGenerator;
        private readonly EmitterConfig _config;
        private readonly float _secondsBetweenEmissions;

        private float _secondSinceLastEmitted;
        private float _numberToEmitFractional;

        private IEmitterShape _shape;
        private IColorCalculator _intialColorCalculator;
        private IColorCalculator _finalColorCalculator;
        private ISizeCalculator _initialSizeCalculator;

        public Particle[] Particles { get; }
        public int ParticleCount { get; private set; }
        public Vector2 Location { get; set; }

        public Emitter(EmitterConfig config)
        {
            _randomGenerator = new RandomWrapper();
            _config = config;
            _shape = config.EmitterShape;
            _intialColorCalculator = config.InitialColorCalculator;
            _finalColorCalculator = config.FinalColorCalculator;
            _initialSizeCalculator = config.InitialSizeCalculator;
            _secondsBetweenEmissions = 1.0f / config.EmissionRatePerSecond;
            Particles = new Particle[config.MaximumNumberOfParticles];
            ParticleCount = 0;
            _secondSinceLastEmitted = 0.0f;
            _numberToEmitFractional = 0.0f;
        }

        public void Emit(float deltaTime)
        {
            var numberToEmit = CalculateNumberToEmit(deltaTime);

            if (numberToEmit < 1.0f)
            {
                DoOneParticle(deltaTime);
            }
            else
            {
                DoMultipleParticles(numberToEmit);
            }
        }

        private float CalculateNumberToEmit(float deltaTime)
        {
            return _config.EmissionRatePerSecond * deltaTime;
        }

        private void DoOneParticle(float deltaTime)
        {
            if (_secondSinceLastEmitted < _secondsBetweenEmissions)
            {
                _secondSinceLastEmitted += deltaTime;
                return;
            }

            _secondSinceLastEmitted = 0.0f;
            EmitOneParticle();
        }

        private void DoMultipleParticles(float numberToEmit)
        {
            var numberToEmitInteger = (int)numberToEmit;
            var numberToEmitFractional = numberToEmit - numberToEmitInteger;
            _numberToEmitFractional += numberToEmitFractional;
            if (_numberToEmitFractional > 1.0f)
            {
                _numberToEmitFractional = 0.0f;
                EmitOneParticle();
            }

            for (int i = 0; i < numberToEmitInteger; ++i)
            {
                _secondSinceLastEmitted = 0.0f;
                EmitOneParticle();
            }
        }

        private void EmitOneParticle()
        {
            if (ParticleCount >= _config.MaximumNumberOfParticles) return;

            var particle = CreateParticle(Location, 5.0f);
            Particles[ParticleCount] = particle;
            ParticleCount++;
        }

        private Particle CreateParticle(Vector2 location, float lifeTime)
        {
            var offset = _shape.GetLocation();
            var velocity = _shape.GetVelocity(offset);
            location = location + offset;

            var size = _initialSizeCalculator.GetSize();
            var startColor = _intialColorCalculator.GetColor();
            var endColor = _finalColorCalculator.GetColor();

            var particle = new Particle(location, velocity, startColor, startColor, endColor, size, lifeTime);

            return particle;
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < ParticleCount; ++i)
            {
                Update(deltaTime, i);
            }
        }

        private void Update(float deltaTime, int i)
        {
            var particle = Particles[i];
            if (particle.IsAlive)
            {
                var life = new LifeSpan(particle.Life.Maximum, particle.Life.Current - deltaTime);
                var newParticle = new Particle(particle.Position, particle.Velocity, particle.Color, particle.StartingColor, particle.EndingColor, particle.Size, life);

                foreach (var action in _config.Actions)
                {
                    newParticle = action.DoAction(newParticle, deltaTime);
                }

                Particles[i] = newParticle;
            }
            else
            {
                int lastParticleIndex = ParticleCount - 1;
                ParticleCount--;
                if (lastParticleIndex != i)
                {
                    Particles[i] = Particles[lastParticleIndex];
                    Update(deltaTime, i);
                }
            }
        }
    }
}