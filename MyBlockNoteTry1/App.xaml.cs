using System;
using System.Windows;

namespace MyBlockNoteTry1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private EditorFile _file;
        private IWindowFactory _windowsFactory = new MainWindowsFactory();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _file = new TxtFile();
            Window mw = _windowsFactory.CreateMainWindow(ref _file, ref _windowsFactory);
            mw.Show();
        }

        private void Application_Exit(object sender, EventArgs e) { }
    }
}
