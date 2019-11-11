namespace SneakyParticleSystem
{
    public struct ColorRgba
    {
        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }
        public byte A { get; set; }

        public ColorRgba(int r, int g, int b)
        {
            if (r < 0) R = 0;
            else if (r > 255) R = 255;
            else R = (byte)r;

            if (g < 0) G = 0;
            else if (g > 255) G = 255;
            else G = (byte)g;

            if (b < 0) B = 0;
            else if (b > 255) B = 255;
            else B = (byte)b;

            A = 255;
        }

        public ColorRgba(ColorRgba color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = 255;
        }

        public static ColorRgba Lerp(ColorRgba color1, ColorRgba color2, float t)
        {
            var r = (byte)((color2.R - color1.R) * t) + color1.R;
            var g = (byte)((color2.G - color1.G) * t) + color1.G;
            var b = (byte)((color2.B - color1.B) * t) + color1.B;

            return new ColorRgba((byte)r, (byte)g, (byte)b);
        }

        public override string ToString()
        {
            return $"R:{R} G:{G} B:{B} A:{A}";
        }
    }
}