using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace MyBlockNoteTry1
{
    /// <summary>
    /// Логика взаимодействия для ThemeSettingsWindow.xaml
    /// </summary>
    public partial class ThemeSettingsWindow : Window
    {
        private List<Color> _colors;
        private List<ColorPicker> _colorsPickers = new List<ColorPicker>();
        public ThemeSettingsWindow(List<Brush> _brushes)
        {   
            _colors = new List<Color>();
            for(int  i = 0; i < _brushes.Count; i++)
            {
                _colors.Add(((SolidColorBrush)_brushes[i]).Color);
            }
            InitializeComponent();
            InitializeColorPickers();
        }

        private void InitializeColorPickers()
        {
            if (_colorsPickers.Count != _colors.Count)
            {
                throw new Exception("Несовпадение количества ColorPickers и кистей");
            }
            for (int i = 0; i < _colors.Count; i++) 
            {
                _colorsPickers[i].SelectedColor = _colors[i];
            }
                
        }
        private void InitializeColorPickerAdd(object sender, EventArgs e)
        {
            _colorsPickers.Add((ColorPicker)sender);
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            BaseThemeColorAccess.WriteBrushesJson(_colors);
            this.DialogResult = true;
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            _colors = BaseThemeColorAccess.GetBaseColorsList();
            InitializeColorPickers();
        }

        private void ColorPickerBackground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            _colors[0] = (Color)ColorPickerBackground.SelectedColor;
        }

        private void ColorPickerFont_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            _colors[1] = (Color)ColorPickerFont.SelectedColor;
        }

        private void ColorPickerSelector_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            _colors[2] = (Color)ColorPickerSelector.SelectedColor;
        }
    }
}
