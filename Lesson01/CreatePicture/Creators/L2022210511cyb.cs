using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePicture.Creators
{
    internal class L2022210511cyb : PictureCreator
    {
        public override int B(int x, int y)
        {
            if (x * y == 1)
                return 1;
            else
                return 0;
        }

        public override int G(int x, int y)
        {
            if (x * y == 0)
                return 1;
            else
                return 0;
        }

        public override int R(int x, int y)
        {
            if (x * y < 256)
                return x * y;
            else
                return (x * y - 256) / 3;
        }

    }
}
