using Ninject;
using System;
using System.Data.Linq;
using System.Windows;
using TestProgram.Views;

namespace TestProgram
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public sealed partial class App : Application
    {
         
        protected override void OnStartup(StartupEventArgs e)
        { 
            base.OnStartup(e); 
            MainWindow view = new MainWindow();
            view.Show(); 
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception is InvalidOperationException)
                e.Handled = true;
        }
    }
}
