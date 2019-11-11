namespace SneakyParticleSystem
{
    public interface ISizeCalculator
    {
        float GetSize();
    }

    public class RandomBetweenXAndY : ISizeCalculator
    {
        private readonly float _minValue;
        private readonly float _maxValue;
        private readonly IRandom _random;

        public RandomBetweenXAndY(float minValue, float maxValue, IRandom random)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _random = random;
        }

        public float GetSize()
        {
            var size = _random.NextFloat(_minValue, _maxValue);

            return size;
        }
    }
}