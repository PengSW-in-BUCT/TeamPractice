using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CreatePicture.Creators
{
    internal class L2022210521 : PictureCreator
    {
        public override int R(int x, int y)
        {
            return x % 255;
        }
        

        public override int G(int x, int y)
        {
            return x % (rand(254) + 1);
        }

        public override int B(int x, int y)
        {
            return 125;
        }
    }
}
