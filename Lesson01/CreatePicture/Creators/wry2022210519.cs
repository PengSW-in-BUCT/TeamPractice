using System;

namespace CreatePicture.Creators
{
    internal class wry2022210519: PictureCreator
    {
        public override void SetSize(int aWidth, int aHeight)
        {
            base.SetSize(aWidth, aHeight);
            _r = new int[W, H];
            _g = new int[W, H];
            _b = new int[W, H];
        }

        private int GetColor(int x, int y, int[,] c)
        {
            if (c[x, y] == 0)
            {
                if (r(999) == 0) c[x, y] = r(512);
                else c[x, y] = GetColor((x + r(5)) % W, (y + r(5)) % W, c);
            }
            return c[x, y];
        }

        public override int B(int x, int y)
        {
            return GetColor(x, y, _b);
        }

        public override int G(int x, int y)
        {
            return GetColor(x, y, _g);
        }

        public override int R(int x, int y)
        {
            return GetColor(x, y, _r);
        }

        private int r(int n) { return _random.Next() % n; }
        private int[,] _r = new int[1024, 1024];
        private int[,] _g = new int[1024, 1024];
        private int[,] _b = new int[1024, 1024];
    }
}
