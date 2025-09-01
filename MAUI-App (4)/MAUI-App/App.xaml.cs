using Notes.Models;
using System.Collections.ObjectModel;

namespace Notes
{
    public partial class App : Application
    {
        public static ObservableCollection<Note> NotesCollection { get; set; } = new();

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
