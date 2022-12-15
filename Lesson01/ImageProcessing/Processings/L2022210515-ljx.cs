using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Processings
{
    internal class L2022210515_ljx : Processing
    {
        public override string Name => "加15像素黑框";

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            // 上边框
            int aIndex = 0;
            for (int j = 0; j < 15; j++)
            {
                for (int i = 0; i < aStride; i++) aSourceRawData[aIndex + i] = 0;
                aIndex += aStride;
            }
            // 下边框
            aIndex = (aPixelHeight - 15) * aStride;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < aStride; i++) aSourceRawData[aIndex + i] = 0;
                aIndex += aStride;
            }
            // 左边框
            aIndex = 0;
            for (int i = 0; i < aPixelHeight; i++)
            {
                for (int j = 0; j < 15 * aBytesPerPixel; j++) aSourceRawData[aIndex + j] = 0;
                aIndex += aStride;
            }
            // 右边框
            aIndex = (aPixelWidth - 15) * aBytesPerPixel;
            for (int i = 0; i < aPixelHeight; i++)
            {
                for (int j = 0; j < 15 * aBytesPerPixel; j++) aSourceRawData[aIndex + j] = 0;
                aIndex += aStride;
            }
            return aSourceRawData;
        }
    }
}



