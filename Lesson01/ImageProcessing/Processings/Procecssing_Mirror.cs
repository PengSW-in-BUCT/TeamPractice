using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Processings
{
    internal class Procecssing_Mirror : Processing
    {
        public override string Name => "镜像";

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            int aRowIndex = 0;
            for (int i = 0; i < aPixelHeight; i++)
            {
                for (int s = 0, t = aStride - aBytesPerPixel; s < t; s += aBytesPerPixel, t -= aBytesPerPixel)
                {
                    for (int k = 0; k < aBytesPerPixel; k++)
                    {
                        byte temp = aSourceRawData[aRowIndex + s + k];
                        aSourceRawData[aRowIndex + s + k] = aSourceRawData[aRowIndex + t + k];
                        aSourceRawData[aRowIndex + t + k] = temp;
                    }
                }
                aRowIndex += aStride;
            }
            return aSourceRawData;
        }
    }
}
