using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ImageProcessing.Processings
{
    public class Processing_IncConstrast : Processing
    {
        public Processing_IncConstrast()
        {
            Control = new Ui_Slider(this);
        }
        public override string Name => "Constrast";
        public override UserControl Control { get; }
        public double Level { get; set; } = 50;

        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            double c = (Level-50)/50;
            double k = Math.Tan((45+44*c)/180 * Math.PI);

            for (int i = 0; i < aSourceRawData.Length; i++)
            { int abyte = (int)((aSourceRawData[i] - 127.5) * k + 127.5);
                if (abyte > 255) abyte = 255;
                if (abyte < 0) abyte = 0; 
                aSourceRawData[i] = (byte)abyte; 
            }
            return aSourceRawData;
        }
    }
}
