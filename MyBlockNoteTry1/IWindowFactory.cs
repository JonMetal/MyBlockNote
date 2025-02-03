using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MyBlockNoteTry1
{
    public interface IWindowFactory
    {
        Window CreateMainWindow(ref EditorFile editorFile, ref IWindowFactory windowFactory);
        Window CreateFontSettingWindow(ref EditorFile editorFile);

        Window CreateThemeSettingWindow(List<Brush> brushes);

        Window CreateAboutProgramWindow();
    }
}
