using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Processings
{
    internal class Processing_2022210521 : Processing
    {
        public override string Name => "2022210521";

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
            // 上边框
            int aIndex = 0;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < aStride; i++) aSourceRawData[aIndex + i] = 0;
                aIndex += aStride;
            }
            // 下边框
            aIndex = (aPixelHeight - 5) * aStride;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < aStride; i++) aSourceRawData[aIndex + i] = 0;
                aIndex += aStride;
            }
            // 左边框
            aIndex = 0;
            for (int i = 0; i < aPixelHeight; i++)
            {
                for (int j = 0; j < 5 * aBytesPerPixel; j++) aSourceRawData[aIndex + j] = 0;
                aIndex += aStride;
            }
            // 右边框
            aIndex = (aPixelWidth - 5) * aBytesPerPixel;
            for (int i = 0; i < aPixelHeight; i++)
            {
                for (int j = 0; j < 5 * aBytesPerPixel; j++) aSourceRawData[aIndex + j] = 0;
                aIndex += aStride;
            }
            return aSourceRawData;
        }
    }
}