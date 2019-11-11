namespace SneakyParticleSystem
{
    public struct LifeSpan
    {
        public float Maximum { get; set; }
        public float Current { get; set; }
        public float AgeRatio => 1 - (Current / Maximum);

        public LifeSpan(float max)
        {
            Maximum = max;
            Current = max;
        }

        public LifeSpan(float max, float current)
        {
            Maximum = max;
            Current = current;
        }

        public override string ToString()
        {
            return $"Current:{Current} Maximum:{Maximum}";
        }
    }

    public struct LifeSpan2
    {
        public float Maximum { get; set; }
        public float Current { get; set; }
        public float AgeRatio => Current / Maximum;

        public LifeSpan2(float max)
        {
            Maximum = max;
            Current = max;
        }

        public LifeSpan2(float max, float current)
        {
            Maximum = max;
            Current = current;
        }

        public override string ToString()
        {
            return $"Current:{Current} Maximum:{Maximum} AgeRatio:{AgeRatio}";
        }
    }
}