using System.Collections.ObjectModel;
using System.Text.Json;

namespace Notes.Models
{
    public class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public void LoadNotes()
        {
            Notes.Clear();

            string appDataPath = FileSystem.AppDataDirectory;
            var files = Directory.EnumerateFiles(appDataPath, "*.note.json");

            foreach (var filename in files)
            {
                try
                {
                    var json = File.ReadAllText(filename);
                    var note = JsonSerializer.Deserialize<Note>(json);
                    if (note != null)
                    {
                        note.Filename = filename;
                        Notes.Add(note);
                    }
                }
                catch
                {
                    // Ignore corrupted files
                }
            }
        }
    }
}
