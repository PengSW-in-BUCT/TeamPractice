using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImageProcessing.Processings
{
    internal class Processing_2022210524 : Processing
    {
        public override string Name => "上下翻转-2022210524";

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            for (int i = 0; i < aPixelWidth * aBytesPerPixel; i++) // 遍历每一列
            {
                for(int s = 0, t = aPixelHeight - 1; s < t; s++, t--)
                {
                    byte temp = aSourceRawData[s * aStride + i];
                    aSourceRawData[s * aStride + i] = aSourceRawData[t * aStride + i];
                    aSourceRawData[t * aStride + i] = temp;
                }
            }
            return aSourceRawData;
        }
    }
}
