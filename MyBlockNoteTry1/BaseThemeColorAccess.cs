using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Media;
using System.IO;

namespace MyBlockNoteTry1
{
    public static class BaseThemeColorAccess
    {
        public static Color GetBaseBackground()
        {
            return Color.FromRgb(255, 255, 255);
        }

        public static Color GetBaseForeground()
        {
            return Color.FromRgb(0, 0, 0);
        }

        public static Color GetBaseSelectionBrush()
        {
            return Color.FromRgb(0, 120, 215);
        }
        
        public static List<Color> GetBaseColorsList()
        {
            return new List<Color> {GetBaseBackground(), GetBaseForeground(), GetBaseSelectionBrush()};
        }
        public static List<Color> GetBlackColorsList()
        {
            return new List<Color> { Color.FromRgb(26, 26, 26), Color.FromRgb(255, 255, 255), GetBaseSelectionBrush() };
        }

        public static void WriteBrushesJson(List<Color> brushes)
        {
            string brushesJson = JsonConvert.SerializeObject(brushes);
            File.WriteAllText(@"brushes.json", brushesJson);
        }

        public static string GetBrushesJson()
        {
            return File.ReadAllText(@"brushes.json");
        }
    }
}
