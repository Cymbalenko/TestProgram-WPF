using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestProgram.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditQuestionWindow.xaml
    /// </summary>
    public partial class AddAndEditQuestionWindow : Window
    {
        internal AddAndEditQuestionWindow()
        {
            InitializeComponent();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
