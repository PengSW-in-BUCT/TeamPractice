using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using CreatePicture.Creators;
using System;

namespace CreatePicture
{
    internal  class CreatePictureModel : INotifyPropertyChanged
    {
        public CreatePictureModel()
        {
            var aAssembly = this.GetType().Assembly;
            CreatorTypes = (from r in aAssembly.GetTypes() where r?.BaseType == typeof(PictureCreator) select r).ToArray();
        }
        public Type[] CreatorTypes { get; }

        public int Width { get => _Width; set { if (_Width == value) return; _Width = value < 10 ? 10 : value; OnPropertyChanged(nameof(Width)); } }
        private int _Width = 1024;

        public int Height { get => _Height; set { if (_Height == value) return; _Height = value < 10 ? 10 : value; OnPropertyChanged(nameof(Height)); } }
        private int _Height = 1024;

        public BitmapSource Picture { get => _Picture; set { if (_Picture == value) return; _Picture = value; OnPropertyChanged(nameof(Picture)); } }
        private BitmapSource _Picture;

        private readonly PixelFormat _Format = PixelFormats.Bgr24;

        public void CreatePicture(Type aCreatorType)
        {
            if (aCreatorType == null) return;
            PictureCreator aCreator = this.GetType().Assembly.CreateInstance(aCreatorType.FullName) as PictureCreator;
            if (aCreator == null) return;

            aCreator.SetSize(Width, Height);

            // 生成图像
            int aStride = (_Format.BitsPerPixel * Width + 7) / 8;
            byte[] aPixels = new byte[aStride * Height];
            int aRowIndex = 0;
            for (int y = 0; y < Height; y++)
            {
                int i = aRowIndex;
                for (int x = 0; x < Width; x++)
                {
                    aPixels[i++] = (byte)aCreator.B(x, y);
                    aPixels[i++] = (byte)aCreator.G(x, y);
                    aPixels[i++] = (byte)aCreator.R(x, y);
                }
                aRowIndex += aStride;
            }
            Picture = BitmapImage.Create(Width, Height, 96, 96, _Format, null, aPixels, aStride);
        }

        private void OnPropertyChanged([CallerMemberName] string aPropertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
