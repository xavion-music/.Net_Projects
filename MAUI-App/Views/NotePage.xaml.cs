using Notes.Models;
using Microsoft.Maui.Media;
using System.Text.Json;

namespace Notes.Views
{
    public partial class NotePage : ContentPage
    {
        Note note;

        public NotePage(Note note)
        {
            InitializeComponent();
            this.note = note;
            BindingContext = this.note;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                note.Filename = Path.Combine(
                    FileSystem.AppDataDirectory,
                    $"{Path.GetRandomFileName()}.note.json");
            }
            note.Date = DateTime.Now;

            var json = JsonSerializer.Serialize(note);
            File.WriteAllText(note.Filename, json);

            await Navigation.PopAsync();
        }

        private async void OnTakePhotoClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    var newFile = Path.Combine(FileSystem.AppDataDirectory, $"{Path.GetRandomFileName()}.jpg");
                    using var stream = await photo.OpenReadAsync();
                    using var newStream = File.OpenWrite(newFile);
                    await stream.CopyToAsync(newStream);

                    note.PhotoPath = newFile;
                    OnPropertyChanged(nameof(note.PhotoPath));
                    PhotoPreview.Source = note.PhotoPath;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Camera Error", ex.Message, "OK");
            }
        }
    }
}
