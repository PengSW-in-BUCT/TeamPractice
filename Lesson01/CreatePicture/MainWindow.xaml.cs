using System;
using System.Windows;
using System.Windows.Input;
using CreatePicture.Creators;

namespace CreatePicture
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private CreatePictureModel _Model => DataContext as CreatePictureModel;

        private void OnCreatePicture_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                _Model.CreatePicture(e.Parameter as Type);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnCreatePicture_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = e.Parameter is Type;
        }
    }
}
