using System;

namespace ImageProcessing.Processings
{
    public class Processing_2022210518 : Processing
    {
        public override string Name => "2022210518";

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            int i = 0;
            for (int row = 0; row < aPixelHeight; row++)
            {
                for (int j = 0; j < aStride; j += 4)
                {
                    aSourceRawData[i + j] = (byte)(aSourceRawData[i + j]-14);
                    aSourceRawData[i + j + 1] = (byte)(aSourceRawData[i + j + 1]-13);
                    aSourceRawData[i + j + 3] = (byte)(aSourceRawData[i + j + 3]-199);
                    aSourceRawData[i + j + 2] = (byte)(aSourceRawData[i + j + 2]-199);
                }
                i += aStride;
            }
            int aRowIndex = 0;
            for (int j = 0; j < aPixelHeight; j++)
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