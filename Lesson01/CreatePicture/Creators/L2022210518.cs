using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePicture.Creators
{
    internal class L2022210518 : PictureCreator
    {
        public override int B(int x, int y)
        {
            return x % 14;
        }

        public override int G(int x, int y)
        {
            return y % 13;
        }

        public override int R(int x, int y)
        {
            return x % 19;
        }
    }
}
