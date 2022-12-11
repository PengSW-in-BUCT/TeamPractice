using System;
using System;

namespace ImageProcessing.Processings
{
    public class lkx_2022210512 : Processing
    {
        public override string Name => "2022210512";

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            int i = 0;
            for (int row = 0; row < aPixelHeight; row++)
            {
                for (int j = 0; j < aStride; j += 4)
                {
                    byte temp = aSourceRawData[i + j];
                    aSourceRawData[i + j] = aSourceRawData[i + j + 1] ;
                    aSourceRawData[i + j + 1] = temp;
                }
                i += aStride;
            }
            return aSourceRawData;
        }
    }
}
