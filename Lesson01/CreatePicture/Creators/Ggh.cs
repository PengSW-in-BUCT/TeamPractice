using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePicture.Creators
{
    internal class Ggh00000000 : PictureCreator
    {

        public override int B(int x, int y)
        {
            return (int)(_sq(cos(atan2(y - H / 3, x - W / 3) / 3)) * 255);
        }

        public override int G(int x, int y)
        {
            return (int)(_sq(cos(atan2(y - H / 5, x - W / 2) / 2 - 2 * acos(-1) / 3)) * 255);
        }

        public override int R(int x, int y)
        {
            return (int)(_sq(cos(atan2(y - H / 1, x - W / 2) / 4)) * 255);
        }
     
    }


}
