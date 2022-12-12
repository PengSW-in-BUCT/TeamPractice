namespace CreatePicture.Creators
{
    internal class L2022210482 : PictureCreator
    {
        public override int B(int x, int y)
        {
            return (int)(_sq(sin((atan2(y - H / 2, x - W / 2) / 2))) * 255);
        }

        public override int G(int x, int y)
        {
            double _x = 0, _y = 0;
            int k;
            for (k = 0; k < 256; k++)
            {
                double a = _x * _x - _y * _y + (x - 768.0) / 512;
                _y = 2 * _x * _y + (y - 512.0) / 512;
                _x = a;
                if (_x * _x + _y * _y > 4) break;
            }
            return k;
        }

        public override int R(int x, int y) => rand(C);
    }
}

