using System;
using System.Windows.Controls;

namespace ImageProcessing.Processings
{
    public class Processing_IncBrightness : Processing
    {
        public Processing_IncBrightness()
        {
            Control = new Ui_Slider(this);
        }
        public override string Name => "Brightness";
        public override UserControl Control { get; }
        public double Level { get; set; } = 50.0;
        
        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {
            for (int i = 0; i < aSourceRawData.Length; i++) 
            {
                int abyte = (int)(aSourceRawData[i] * (1+(Level-50)/50));
                if (abyte > 255) abyte = 255;
                if (abyte < 0) abyte = 0; 
                aSourceRawData[i] = (byte)abyte; 
            }
            return aSourceRawData;
        }
    }
}
