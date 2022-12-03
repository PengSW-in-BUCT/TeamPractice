namespace CreatePicture.Creators
{
    internal class Sample05 : PictureCreator
    {
        public override int B(int x, int y)
        {
            double s = 3.0 / (y + 99);
            double _y = (y + sin((x * x + _sq(y - 700) * 5) / 100.0 / W) * 35) * s;
            return ((int)(29 * ((x + W) * s + _y)) % 2 + (int)(29 * ((W * 2 - x) * s + _y)) % 2) * 127;
        }

        public override int G(int x, int y)
        {
            double s = 3.0 / (y + 99);
            double _y = (y + sin((x * x + _sq(y - 700) * 5) / 100.0 / W) * 35) * s;
            return ((int)(5 * ((x + W) * s + _y)) % 2 + (int)(5 * ((W * 2 - x) * s + _y)) % 2) * 127;
        }

        public override int R(int x, int y)
        {
            double s = 3.0 / (y + 99);
            double _y = (y + sin((x * x + _sq(y - 700) * 5) / 100.0 / W) * 35) * s;
            return ((int)((x + W) * s + _y) % 2 + (int)((W * 2 - x) * s + _y) % 2) * 127;
        }
    }
}
