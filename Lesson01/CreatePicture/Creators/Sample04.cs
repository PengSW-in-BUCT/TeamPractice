using System;

namespace CreatePicture.Creators
{
    internal class Sample04 : PictureCreator
    {
        public override int B(int x, int y)
        {
            _b += rand(); int l = (int)_b % 512; return l > 255 ? 511 - l : l;
        }

        public override int G(int x, int y)
        {
            _g += rand(); int l = (int)_g % 512; return l > 255 ? 511 - l : l;
        }

        public override int R(int x, int y)
        {
            _r += rand(); int l = (int)_r % 512; return l > 255 ? 511 - l : l;
        }

        private double _r;
        private double _g;
        private double _b;
        private new Random _random = new Random();
        private new double rand() { return _random.NextDouble(); }
    }
}
