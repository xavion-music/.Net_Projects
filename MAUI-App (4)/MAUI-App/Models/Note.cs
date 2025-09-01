using System;
using System.ComponentModel;

namespace Notes.Models
{
    public class Note : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _title;
        private string _text;
        private string _photoPath;
        private DateTime _date = DateTime.Now;

        public string Title
        {
            get => _title;
            set { _title = value; PropertyChanged?.Invoke(this, new(nameof(Title))); }
        }

        public string Text
        {
            get => _text;
            set { _text = value; PropertyChanged?.Invoke(this, new(nameof(Text))); }
        }

        public string PhotoPath
        {
            get => _photoPath;
            set { _photoPath = value; PropertyChanged?.Invoke(this, new(nameof(PhotoPath))); }
        }

        public DateTime Date
        {
            get => _date;
            set { _date = value; PropertyChanged?.Invoke(this, new(nameof(Date))); }
        }
    }
}
