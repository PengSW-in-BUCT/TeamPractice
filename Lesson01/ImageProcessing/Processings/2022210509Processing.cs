using System;

namespace ImageProcessing.Processings
{
    public class Processing_2022210509 : Processing
    {
        public override string Name => "2022210509-刘洋滔的处理-更粗的边框";

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            // 上边框
            int aIndex = 0;
            byte red = 0;
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < aStride; i++) aSourceRawData[aIndex + i] = red;
                aIndex += aStride;
            }
            // 下边框
            aIndex = (aPixelHeight - 10) * aStride;
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < aStride; i++) aSourceRawData[aIndex + i] = red;
                aIndex += aStride;
            }
            // 左边框
            aIndex = 0;
            for (int i = 0; i < aPixelHeight; i++)
            {
                for (int j = 0; j < 10 * aBytesPerPixel; j++) aSourceRawData[aIndex + j] = red;
                aIndex += aStride;
            }
            // 右边框
            aIndex = (aPixelWidth - 10) * aBytesPerPixel;
            for (int i = 0; i < aPixelHeight; i++)
            {
                for (int j = 0; j < 10 * aBytesPerPixel; j++) aSourceRawData[aIndex + j] = red;
                aIndex += aStride;
            }
            return aSourceRawData;
        }
    }
}
