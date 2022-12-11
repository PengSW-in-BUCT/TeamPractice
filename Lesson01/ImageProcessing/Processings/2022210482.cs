using System;
using System.Windows.Controls;

namespace ImageProcessing.Processings
{
    public class Processing_myprocess : Processing
    {
        public Processing_myprocess() => Control = new Ui_Slider(this);
        public override string Name => "加边框";
        public override UserControl Control { get; }
        public int Level { get; set; } = 50;
        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            // 上边框
            int aIndex = 0;
            for (int j = 0; j < Level; j++)
            {
                for (int i = 0; i < aStride; i++) aSourceRawData[aIndex + i] = 0;
                aIndex += aStride;
            }
            // 下边框
            aIndex = (aPixelHeight - Level) * aStride;
            for (int j = 0; j < Level; j++)
            {
                for (int i = 0; i < aStride; i++) aSourceRawData[aIndex + i] = 0;
                aIndex += aStride;
            }
            // 左边框
            aIndex = 0;
            for (int i = 0; i < aPixelHeight; i++)
            {
                for (int j = 0; j < Level * aBytesPerPixel; j++) aSourceRawData[aIndex + j] = 0;
                aIndex += aStride;
            }
            // 右边框
            aIndex = (aPixelWidth - Level) * aBytesPerPixel;
            for (int i = 0; i < aPixelHeight; i++)
            {
                for (int j = 0; j < Level * aBytesPerPixel; j++) aSourceRawData[aIndex + j] = 0;
                aIndex += aStride;
            }
            return aSourceRawData;
        }
    }
}