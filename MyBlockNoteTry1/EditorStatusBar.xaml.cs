using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyBlockNoteTry1
{
    /// <summary>
    /// Логика взаимодействия для EditorStatusBar.xaml
    /// </summary>
    public partial class EditorStatusBar : UserControl
    {
        private ProxyTextBoxCaret _caret;
        private List<Control> _controlsBackground = new List<Control>();
        private List<Control> _controlsForeground = new List<Control>();
        public EditorStatusBar()
        {
            InitializeComponent();
            _caret = new ProxyTextBoxCaret();
            this.DataContext = _caret;
        }

        public void LinkTextBox(ref TextBox textBox)
        {
            _caret.LinkTextBox(ref textBox);
        }

        public void UpdateCaretIndex() 
        { 
            _caret.UpdateCaretIndex();
        }

        private void Label_Initialized(object sender, EventArgs e)
        {
            _controlsForeground.Add(sender as Control);
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            _controlsBackground.Add(sender as Control);
        }

        public void UpdateThemeColors()
        {
            string brushesJson = BaseThemeColorAccess.GetBrushesJson();
            List<Brush> brushes = JsonConvert.DeserializeObject<List<Brush>>(brushesJson);
            foreach (Control control in _controlsBackground)
            {
                control.Background = brushes[0];
            }
            foreach (Control control in _controlsForeground)
            {
                control.Foreground = brushes[1];
            }
        }
    }
}
