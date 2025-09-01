using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace KarandeepFinalExam.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NotePage : ContentPage
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

        public string ItemId
        {
            set { LoadNote(value); }
        }

        public NotePage()
        {
            InitializeComponent();

            // Create a new note with a unique filename if no existing one
            string appDataPath = FileSystem.AppDataDirectory;
            string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
            LoadNote(Path.Combine(appDataPath, randomFileName));

            // Optional: load default text if file exists
            if (File.Exists(_fileName))
                TextEditor.Text = File.ReadAllText(_fileName);
        }

        private void LoadNote(string fileName)
        {
            var noteModel = new Models.Note { Filename = fileName };

            if (File.Exists(fileName))
            {
                noteModel.Text = File.ReadAllText(fileName);
                noteModel.Date = File.GetCreationTime(fileName);
            }

            // Load image path from separate file
            string imagePathFile = fileName + ".img";
            if (File.Exists(imagePathFile))
                noteModel.ImagePath = File.ReadAllText(imagePathFile);

            BindingContext = noteModel;

            if (!string.IsNullOrWhiteSpace(noteModel.ImagePath))
            {
                NoteImage.Source = noteModel.ImagePath;
                NoteImage.IsVisible = true;
            }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.Note note)
            {
                File.WriteAllText(note.Filename, TextEditor.Text);

                // Save image path
                string imagePathFile = note.Filename + ".img";
                File.WriteAllText(imagePathFile, note.ImagePath ?? "");
            }

            await Shell.Current.GoToAsync("..");
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.Note note)
            {
                // Delete note file
                if (File.Exists(note.Filename))
                    File.Delete(note.Filename);

                // Delete image file
                if (!string.IsNullOrEmpty(note.ImagePath) && File.Exists(note.ImagePath))
                    File.Delete(note.ImagePath);

                // Delete image path file
                string imagePathFile = note.Filename + ".img";
                if (File.Exists(imagePathFile))
                    File.Delete(imagePathFile);
            }

            await Shell.Current.GoToAsync("..");
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (DeviceInfo.Platform != DevicePlatform.Android && DeviceInfo.Platform != DevicePlatform.iOS)
                {
                    await DisplayAlert("Not Supported", "Camera only works on mobile devices.", "OK");
                    return;
                }

                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo == null) return;

                string localPath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using var stream = await photo.OpenReadAsync();
                using var newFile = File.OpenWrite(localPath);
                await stream.CopyToAsync(newFile);

                if (BindingContext is Models.Note note)
                {
                    note.ImagePath = localPath;
                    NoteImage.Source = localPath;
                    NoteImage.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Camera failed: {ex.Message}", "OK");
            }
        }

        private async void UploadPhoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Select an image"
                });

                if (result == null) return;

                string localPath = Path.Combine(FileSystem.AppDataDirectory, result.FileName);
                using var stream = await result.OpenReadAsync();
                using var newFile = File.OpenWrite(localPath);
                await stream.CopyToAsync(newFile);

                if (BindingContext is Models.Note note)
                {
                    note.ImagePath = localPath;
                    NoteImage.Source = localPath;
                    NoteImage.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Image upload failed: {ex.Message}", "OK");
            }
        }
    }
}
