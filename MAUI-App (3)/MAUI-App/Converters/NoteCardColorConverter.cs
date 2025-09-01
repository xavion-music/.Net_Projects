using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Notes.Converters
{
    public class NoteCardColorConverter : IValueConverter
    {
        private static readonly string[] PastelColors = new[]
        {
            "PastelPurple", "PastelPink", "PastelBrightPink", "PastelLightBlue", "PastelBlue"
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Notes.Models.Note note)
            {
                // Hash by title for color variety
                int idx = Math.Abs((note.Title ?? "").GetHashCode()) % PastelColors.Length;
                return Application.Current.Resources[PastelColors[idx]] as Color;
            }
            return Application.Current.Resources["PastelBlue"] as Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
