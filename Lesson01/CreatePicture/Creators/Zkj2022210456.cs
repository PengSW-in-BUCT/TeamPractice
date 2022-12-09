using System;
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
            double _x = 0, _y = 0;
            int k;
            for (k = 0; k < 128; k++)
            {
                double a = _x * _x - _y * _y + (x - 768.0) / 512;
                _y = 2 * _x * _y + (y - 512.0) / 512;
                _x = a;
                if (_x * _x + _y * _y > 4) break;
            }
            return k;
        }

        public override int G(int x, int y)
        {
            double _x = 0, _y = 0;
            int k;
            for (k = 0; k < 128; k++)
            {
                double a = _x * _x - _y * _y + (x - 768.0) / 512;
                _y = 2 * _x * _y + (y - 512.0) / 512;
                _x = a;
                if (_x * _x + _y * _y > 4) break;
            }
            return k > 63 ? 128 : k * 4;
        }

        public override int R(int x, int y)
        {
            double _x = 0, _y = 0;
            int k;
            for (k = 0; k++ < 128;)
            {
                double a = _x * _x - _y * _y + (x - 768.0) / 512;
                _y = 2 * _x * _y + (y - 512.0) / 512;
                _x = a;
                if (_x * _x + _y * _y > 4) break;
            }
            return k > 31 ? 128 : k * 8;
        }
    }
}
