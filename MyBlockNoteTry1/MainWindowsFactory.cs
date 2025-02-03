using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MyBlockNoteTry1
{
    internal class MainWindowsFactory : IWindowFactory
    {
        public MainWindowsFactory() { }

        public Window CreateMainWindow(ref EditorFile editorFile, ref IWindowFactory windowFactory)
        {
            return new MainWindow(ref editorFile, ref windowFactory);
        }
        public Window CreateAboutProgramWindow()
        {
            return new AboutProgramWindow();
        }

        public Window CreateFontSettingWindow(ref EditorFile editorFile)
        {
            return new FontSettingsWindow(ref editorFile);
        }

        public Window CreateThemeSettingWindow(List<Brush> brushes)
        {
            return new ThemeSettingsWindow(brushes);
        }
    }
}
