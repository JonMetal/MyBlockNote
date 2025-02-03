using System.Drawing.Text;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace MyBlockNoteTry1
{
    /// <summary>
    /// Логика взаимодействия для FontSettings.xaml
    /// </summary>
    public partial class FontSettingsWindow : Window
    {
        private EditorFile _file;

        public FontSettingsWindow(ref EditorFile file)
        {
            InitializeComponent();
            _file = file;
            this.DataContext = _file;

            InstalledFontCollection ifc = new InstalledFontCollection();
            lvFontFamilys.ItemsSource = ifc.Families.Select(FontFamily => FontFamily.Name);
            lvFontSize.ItemsSource = new double[] { 12, 14, 16, 18, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38 };
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
