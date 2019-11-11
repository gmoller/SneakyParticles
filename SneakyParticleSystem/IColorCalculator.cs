namespace SneakyParticleSystem
{
    public interface IColorCalculator
    {
        ColorRgba GetColor();
    }

    public class Simple : IColorCalculator
    {
        private ColorRgba _startingColor;

        public Simple(ColorRgba startingColor)
        {
            _startingColor = startingColor;
        }

        public ColorRgba GetColor()
        {
            var color = _startingColor;

            return color;
        }
    }

    public class Varied : IColorCalculator
    {
        private ColorRgba _startingColor;
        private ColorRgba _variance;
        private IRandom _random;

        public Varied(ColorRgba startingColor, ColorRgba variance, IRandom random)
        {
            _startingColor = startingColor;
            _variance = variance;
            _random = random;

        }

        public ColorRgba GetColor()
        {
            var r1 = _random.Next(-_variance.R, _variance.R);
            var g1 = _random.Next(-_variance.G, _variance.G);
            var b1 = _random.Next(-_variance.B, _variance.B);
            var color = new ColorRgba(_startingColor.R + r1, _startingColor.G + g1, _startingColor.B + b1);

            return color;
        }
    }
}