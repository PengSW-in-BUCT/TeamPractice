using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;using System.Windows.Controls;
using System.Security.Cryptography;
using static OpenCvSharp.LineIterator;
using System.Windows.Media.Media3D;
using OpenCvSharp.Flann;

namespace ImageProcessing.Processings
{
    public class P2022210456 : Processing
    {
        //public P2022210456()
        //{
        //    Control = new Ui_Slider(this);
        //}
        public override string Name => "Sharpening";
        //public override UserControl Control { get; }
        //public double Level { get; set; } = 50.0;
      
        protected override byte[] ProcessImage(byte[] aSourceRawData, ref int aPixelWidth, ref int aPixelHeight, int aBytesPerPixel, ref int aStride)
        {

            int[] Laplacian = { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
            //double r, g, b;
            //r = g = b = 0;
            //int Index = 0;
            for (int i = 3; i < aSourceRawData.Length; i += 4)
            {

                int r = 0, g = 0, b = 0;
                int Index = 0;
                for (int col = -1; col <= 1; col++)
                {
                    for (int row = -1; row <= 1; row++)
                    {
                        r += aSourceRawData[i - 1] * Laplacian[Index];
                        g += aSourceRawData[i - 2] * Laplacian[Index];
                        b += aSourceRawData[i - 3] * Laplacian[Index];
                        Index++;


                    }
                    r = r > 255 ? 255 : r;
                    r = r < 0 ? 0 : r;
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;
                    b = b > 255 ? 255 : b;
                    b = b < 0 ? 0 : b;
                }
                
                aSourceRawData[i - 3] = (byte)b;
                aSourceRawData[i - 2] = (byte)g;
                aSourceRawData[i - 1] = (byte)r;


                //处理颜色值溢出

            }
            return aSourceRawData;
        }
    }
}
//for (int x = 1; x < Width - 1; x++)
//    for (int y = 1; y < Height - 1; y++)
//    {
//        int r = 0, g = 0, b = 0;
//        int Index = 0;
//        for (int col = -1; col <= 1; col++)
//            for (int row = -1; row <= 1; row++)
//            {
//                pixel = oldBitmap.GetPixel(x + row, y + col); r += pixel.R * Laplacian[Index];
//                g += pixel.G * Laplacian[Index];
//                b += pixel.B * Laplacian[Index];
//                Index++;
//            }
//        //处理颜色值溢出
//        r = r > 255 ? 255 : r;
//        r = r < 0 ? 0 : r;
//        g = g > 255 ? 255 : g;
//        g = g < 0 ? 0 : g;
//        b = b > 255 ? 255 : b;
//        b = b < 0 ? 0 : b;
//        newBitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
//    }