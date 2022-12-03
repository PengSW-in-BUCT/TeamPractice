using System;

namespace CreatePicture.Creators
{
    internal class Sample01 : PictureCreator
    {
        public override int B(int x, int y)
        {
            return (int)(_sq(cos(atan2(y - H / 2, x - W / 2) / 2)) * 255);
        }

        public override int G(int x, int y)
        {
            return (int)(_sq(cos(atan2(y - H / 2, x - W / 2) / 2 - 2 * acos(-1) / 3)) * 255);
        }

        public override int R(int x, int y)
        {
            return (int)(_sq(cos(atan2(y - H /2, x - W /2) / 2)) * 255);
        }
    }
}
