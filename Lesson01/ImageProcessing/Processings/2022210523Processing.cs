using System;

namespace ImageProcessing.Processings
{
    public class Processing_2022210523 : Processing
    {
        public override string Name => "加一些噪声";

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            int i = 0;
            for (int row = 0; row < aPixelHeight; row++)
            {
                for (int j = 0; j < aStride; j += 4)
                {
                    aSourceRawData[i + j] = (byte)(255);
                }
                i += aStride;
            }
            return aSourceRawData;
        }
    }
}