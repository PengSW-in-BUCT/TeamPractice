using System;

namespace ImageProcessing.Processings
{
    public class Processing_2022210513 : Processing
    {
        public override string Name => "2022210513";

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            double r, g, b;
            r = g = b = 0;
            for (int i = 3; i < aSourceRawData.Length; i += 4)
            {
                b = aSourceRawData[i - 3];
                g = aSourceRawData[i - 2];
                r = aSourceRawData[i - 1];

                aSourceRawData[i - 3] = (byte)((g + r) / 2);
                aSourceRawData[i - 2] = (byte)((b + r) / 2);
                aSourceRawData[i - 1] = (byte)((b + g) / 2);
            }
            return aSourceRawData;
        }
    }
}
