using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ImageProcessing.Processings
{
    internal class L2022210511 : Processing
    {
        public override string Name => "L20222010511";
        public L2022210511()
        {
            Control = new Ui_Slider(this);
        }
        public override UserControl Control { get; }
        public double windows { get; set; } = 10.0;

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {

            int window = (int)windows;
            int i = 0;
            for (int row = 0; row < aPixelHeight; row++)
            {
                for (int j = 0; j < aStride; j += 4)
                {
                    if (row >= window && row <= aPixelHeight - window && j >= window && j <= aStride - window)
                    {
                        int s = 0;
                        int start = i + j - window / 2 - (window - 1) * aStride;
                        for (int ii = 0; ii < window; ii++)
                        {
                            int start_1 = start + ii * aStride;
                            for (int jj = 0; jj < window; jj++)
                            {
                                s += aSourceRawData[start_1 + jj];
                            }
                        }
                        aSourceRawData[i + j] = (byte)(s / (window * window));
                    }
                }
                i += aStride;
            }
            return aSourceRawData;
        }
    }
}
