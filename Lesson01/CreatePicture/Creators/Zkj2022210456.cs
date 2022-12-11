﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePicture.Creators
{
    internal class Zkj2022210456 : PictureCreator
    {
        public override int B(int x, int y)
        {
            return (int)(_cb(cos(atan2(y - H / 2, x - W / 2) / 2)) * 256);
        }

        public override int G(int x, int y)
        {
            return (int)(_sq(cos(atan2(y -H / 2, x - W / 2) / 2 - 2 * acos(-1) / 3)) * 256);
        }

        public override int R(int x, int y)
        {
            return (int)(_cr(cos(atan2(y -H / 2, x - W / 2) / 2)) * 256);
        }
    }
}
