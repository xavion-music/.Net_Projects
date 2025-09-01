using System.Globalization;
using Notes.Models;

namespace Notes.Converters
{
    public class NoteCardColorConverter : IValueConverter
    {
        private static readonly string[] Pastels = {
            "PastelPurple", "PastelPink", "PastelRose", "PastelBlue", "PastelLightBlue"
        };

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Note note)
            {
                int hash = Math.Abs((note.Title ?? "").GetHashCode());
                string key = Pastels[hash % Pastels.Length];
                return Application.Current.Resources.TryGetValue(key, out var color) ? color : null;
            }
            return Application.Current.Resources["PastelLightBlue"];
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
