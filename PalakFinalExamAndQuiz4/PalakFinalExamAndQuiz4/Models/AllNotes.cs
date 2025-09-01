using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace KarandeepFinalExam.Models
{
    public class AllNotes
    {
        // This collection will be bound to the UI (AllNotesPage.xaml)
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        /// <summary>
        /// Loads all notes from the device storage.
        /// Each note is a .notes.txt file, and its image (if any) is stored in a .img file with the same name.
        /// </summary>
        public void LoadNotes()
        {
            Notes.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            // Get all files ending in .notes.txt
            var noteFiles = Directory.GetFiles(appDataPath, "*.notes.txt")
                                     .OrderByDescending(File.GetCreationTime); // Optional: newest first

            foreach (var file in noteFiles)
            {
                var note = new Note
                {
                    Filename = file,
                    Text = File.ReadAllText(file),
                    Date = File.GetCreationTime(file)
                };

                // Load the image path stored in a corresponding .img file (if it exists)
                string imagePathFile = file + ".img";
                if (File.Exists(imagePathFile))
                {
                    note.ImagePath = File.ReadAllText(imagePathFile);
                }

                Notes.Add(note);
            }
        }
    }
}
