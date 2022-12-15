using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static OpenCvSharp.LineIterator;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace ImageProcessing.Processings
{
    public class Processing_2022210456:Processing
    {
        
        public override string Name => "Laplace";
        
        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            int[] Laplacian = { -1, -1, -1, -1, 10, -1, -1, -1, -1 };
            for (int i = 3; i < aSourceRawData.Length; i += 4)
            {
                int r = 0, g = 0, b = 0;
                int Index = 0;
                for (int t=0;t<9;t++)
                {
                    r += aSourceRawData[i - 1] * Laplacian[Index];
                    g += aSourceRawData[i - 2] * Laplacian[Index];
                    b += aSourceRawData[i - 3] * Laplacian[Index];
                    Index++;
                    
                }
                //处理颜色值溢出
                r = r > 255 ? 255 : r;
                r = r < 0 ? 0 : r;
                g = g > 255 ? 255 : g;
                g = g < 0 ? 0 : g;
                b = b > 255 ? 255 : b;
                b = b < 0 ? 0 : b;
                aSourceRawData[i - 3] = (byte)b;
                aSourceRawData[i-2] =(byte)g;
                aSourceRawData[i-1] =(byte)r;
            }
            return aSourceRawData;
        }
    }
}
