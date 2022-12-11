using System;

namespace ImageProcessing.Processings
{
    public class Processing_2022210509_2 : Processing
    {
        public override string Name => "2022210509-刘洋滔的处理-2";

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            for (int i = 0; i < aSourceRawData.Length; i++) 
            {
                int abyte=1;
                if ((int)aSourceRawData[i] == 1)
                {
                    abyte = 1;
                }
                else
                {
                    abyte = 1;
                }

                aSourceRawData[i] = (byte)abyte; }
            return aSourceRawData;
        }
    }
}
