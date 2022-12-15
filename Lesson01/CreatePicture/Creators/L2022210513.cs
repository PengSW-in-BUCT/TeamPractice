using System;

namespace CreatePicture.Creators
{
    internal class L2022210513 : PictureCreator
    {
        public override int B(int x, int y)
        {
            return ((int)(sin(x + y) * 100));
        }

        public override int G(int x, int y)
        {
            return ((int)(sin(x + y) * 100));
        }

        public override int R(int x, int y)
        {
            return ((int)(sin(x + y) * 100));
        }
    }
}

