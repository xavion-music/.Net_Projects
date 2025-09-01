using Notes.Models;
using Microsoft.Maui.Media;
using System.IO;

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
                    // Refresh UI
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
