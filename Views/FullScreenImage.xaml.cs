using System.Windows;

namespace TestProgram.Views
{
    /// <summary>
    /// Логика взаимодействия для FullScreenImage.xaml
    /// </summary>
    public partial class FullScreenImage : Window
    {
        public FullScreenImage()
        {
            InitializeComponent();
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
