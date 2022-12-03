using System;

namespace CreatePicture.Creators
{
    internal abstract class PictureCreator
    {
        protected const int C = 256;
        protected Random _random = new Random();
        protected int rand() { return _random.Next(); }
        protected int rand(int n) { return _random.Next(n); }
        protected int rand(int s, int t) { return _random.Next(s, t); }
        protected double randdbl() { return _random.NextDouble(); }
        protected double _sq(double x) { return x * x; }
        protected double _cb(double x) { return Math.Abs(x * x * x); }
        protected double _cr(double x) { return Math.Pow(x, 1.0 / 3.0); }
        protected double sin(double x) { return Math.Sin(x); }
        protected double cos(double x) { return Math.Cos(x); }
        protected double atan2(double x, double y) { return Math.Atan2(x, y); }
        protected double acos(double x) { return Math.Acos(x); }
        public int W { get; private set; } = 1024;
        public int H { get; private set; } = 1024;
        public virtual void SetSize(int aWidth, int aHeight)
        {
            W = aWidth;
            H = aHeight;
        }

        public abstract int R(int x, int y);
        public abstract int G(int x, int y);
        public abstract int B(int x, int y);
    }
}
