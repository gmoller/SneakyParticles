namespace SneakyParticleSystem
{
    public struct Size
    {
        public float Maximum { get; set; }
        public float Current { get; set; }

        public Size(float max)
        {
            Maximum = max;
            Current = max;
        }

        internal Size(float max, float ageRatio)
        {
            Maximum = max;
            Current = max * (1 - ageRatio);
        }

        public override string ToString()
        {
            return $"Current:{Current} Maximum:{Maximum}";
        }
    }
}