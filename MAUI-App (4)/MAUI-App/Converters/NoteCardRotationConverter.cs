using System.Globalization;

namespace Notes.Converters
{
    public class NoteCardRotationConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int idx)
                return (idx % 2 == 0) ? -2 : 2; // small tilt
            return 0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
