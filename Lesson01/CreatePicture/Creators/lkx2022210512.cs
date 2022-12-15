using System;

namespace CreatePicture.Creators
{
    internal class lkx2022210512 : PictureCreator
    {
        public override int B(int x, int y)
        {
            return x;
        }

        public override int G(int x, int y)
        {
            return (x+y)/2;
        }

        public override int R(int x, int y)
        {
            return (int)(_sq(cos(atan2(y - H / 2, x - W / 2) / 2)) * 255);
        }
    }
}
