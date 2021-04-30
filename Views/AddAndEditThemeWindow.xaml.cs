using System.Windows;
using TestProgram.Views;

namespace TestProgram.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditThemeWindow.xaml
    /// </summary>
    public partial class AddAndEditThemeWindow : Window
    {
        internal AddAndEditThemeWindow()
        {
            InitializeComponent();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
