using System.ComponentModel;

namespace Notes.Models
{
    public class Note : INotifyPropertyChanged
    {
        private string _title = "";
        private string _text = "";
        private string? _photoPath;
        private DateTime _date = DateTime.Now;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }
        public string Text
        {
            get => _text;
            set { _text = value; OnPropertyChanged(nameof(Text)); }
        }
        public string? PhotoPath
        {
            get => _photoPath;
            set { _photoPath = value; OnPropertyChanged(nameof(PhotoPath)); }
        }
        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
