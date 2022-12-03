using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using ImageProcessing.Processings;

namespace ImageProcessing
{
    class ImageProcessingModel : INotifyPropertyChanged
    {
        public ImageProcessingModel()
        {
            var aAssembly = this.GetType().Assembly;
            var aTypes = (from r in aAssembly.GetTypes() where r?.BaseType == typeof(Processing) select r).ToArray();
            Processings = (from r in aTypes let t = this.GetType().Assembly.CreateInstance(r.FullName) as Processing where t != null select t).ToArray();
        }

        public void LoadSource(string aFileName)
        {
            Uri aUri = new Uri(aFileName);
            SourceImage = new BitmapImage(aUri);
            foreach (Processing aProcessing in Processings) aProcessing.Apply += OnProcessing_Apply;
        }

        private void OnProcessing_Apply(object sender, EventArgs e)
        {
            Exec(sender as Processing);
        }

        public void SaveResult(string aFileName)
        {
            JpegBitmapEncoder aEncoder = new JpegBitmapEncoder();
            aEncoder.Frames.Add(BitmapFrame.Create(ResultImage));
            using (FileStream aStream = new FileStream(aFileName, FileMode.CreateNew))
            {
                aEncoder.Save(aStream);
                aStream.Close();
            }
        }

        public void Exec(Processing aProcessing)
        {
            CurrentProcessing = aProcessing;
            ResultImage = CurrentProcessing?.GetResultImage(SourceImage);
        }

        public BitmapImage SourceImage { get { return _SourceImage; } set { if (_SourceImage == value) return; _SourceImage = value; OnPropertyChanged(nameof(SourceImage)); } }
        private BitmapImage _SourceImage;

        public BitmapSource ResultImage { get { return _ResultImage; } set { if (_ResultImage == value) return; _ResultImage = value; OnPropertyChanged(nameof(ResultImage)); } }
        private BitmapSource _ResultImage;

        public Processing CurrentProcessing { get { return _CurrentProcessing; } set { if (_CurrentProcessing == value) return; _CurrentProcessing = value; OnPropertyChanged(nameof(CurrentProcessing)); } }
        private Processing _CurrentProcessing;

        public Processing[] Processings { get; }

        private void OnPropertyChanged(string aPropertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName)); }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
