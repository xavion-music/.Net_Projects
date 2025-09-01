using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Notes.Models;

namespace Notes.Converters
{
    public class NoteCardRotationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Note note)
            {
                int hash = Math.Abs(note.Title?.GetHashCode() ?? note.GetHashCode());
                // Small random angle: -4 to +4 degrees
                double[] angles = { -3, -2, -1, 0, 1, 2, 3, 4 };
                return angles[hash % angles.Length];
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
