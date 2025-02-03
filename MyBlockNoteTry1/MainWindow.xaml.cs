using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Newtonsoft.Json;

namespace MyBlockNoteTry1
{
    public partial class MainWindow : Window
    {
        public event Action ThemeChanged;
        public event Action CaretChanged;

        private EditorFile _editorFile;
        private IWindowFactory _mainWindowsFactory;

        private List<Brush> _brushes = new List<Brush>();
        private List<Control> _controlsBackground = new List<Control>();
        private List<Control> _controlsForeground = new List<Control>();
        public MainWindow(ref EditorFile file, ref IWindowFactory windowFactory)
        {
            InitializeComponent();
            _mainWindowsFactory = windowFactory;
            _editorFile = file;
            this.DataContext = _editorFile;
            MainEditorStatusBar.LinkTextBox(ref MainTextBox);
            ThemeChanged += UpdateThemeSettings;
            ThemeChanged += MainEditorStatusBar.UpdateThemeColors;
            CaretChanged += MainEditorStatusBar.UpdateCaretIndex;
            ThemeChanged?.Invoke();
        }

        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_editorFile.SaveCheck())
            {
                _editorFile = new TxtFile();
                this.DataContext = _editorFile;
            }
        }

        private void UpdateThemeSettings()
        {
            string brushesJson = BaseThemeColorAccess.GetBrushesJson();
            _brushes = JsonConvert.DeserializeObject<List<Brush>>(brushesJson);
            foreach(Control control in _controlsBackground)
            {
                control.Background = _brushes[0];
            }
            foreach (Control control in _controlsForeground)
            {
                control.Foreground = _brushes[1];
            }
            MainTextBox.SelectionBrush = _brushes[2];
        }
        private void ThemeSettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {

            Window _tSMIWindow = _mainWindowsFactory.CreateThemeSettingWindow(_brushes);
            if (_tSMIWindow.ShowDialog() == true)
            {
                ThemeChanged?.Invoke();
            }
        }

        private void ThemeWhiteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<Color> colors = BaseThemeColorAccess.GetBaseColorsList();
            BaseThemeColorAccess.WriteBrushesJson(colors);
            ThemeChanged?.Invoke();
            var memory = 0.0;
            using (Process proc = Process.GetCurrentProcess())
            {
                memory = proc.PrivateMemorySize64 / (1024 * 1024);
            }
            Console.WriteLine(memory);
        }

        private void ThemeBlackMenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<Color> colors = BaseThemeColorAccess.GetBlackColorsList();
            BaseThemeColorAccess.WriteBrushesJson(colors);
            ThemeChanged?.Invoke();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            _editorFile.OpenFile();
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            _editorFile.SaveFile(true);
        }

        private void MenuItemSaveAs_Click(object sender, RoutedEventArgs e)
        {
            _editorFile.SaveFile();
        }

        private void MenuItemFontSettings_Click(object sender, RoutedEventArgs e)
        {
            Window fs = _mainWindowsFactory.CreateFontSettingWindow(ref _editorFile);
            fs.Show();
        }

        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CaretChanged?.Invoke();
        }

        private void MainTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            CaretChanged?.Invoke();
        }
        private void MainTextBox_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            CaretChanged?.Invoke();
        }

        private void MenuItemInfo_Click(object sender, RoutedEventArgs e)
        {
            Window aboutProgramWindow = _mainWindowsFactory.CreateAboutProgramWindow();
            aboutProgramWindow.Show();
        }

        private void Control_Initialized(object sender, EventArgs e)
        {
            _controlsBackground.Add(sender as Control);
            _controlsForeground.Add(sender as Control);
        }
    }
}