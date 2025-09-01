using Notes.Models;

namespace Notes.Views
{
    public partial class NotePage : ContentPage
    {
        public Note note { get; set; }

        public NotePage(Note existingNote = null)
        {
            InitializeComponent();
            note = existingNote ?? new Note();
            BindingContext = this;
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
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Camera Error", ex.Message, "OK");
            }
        }

        private async void OnSaveNoteClicked(object sender, EventArgs e)
        {
            if (!App.NotesCollection.Contains(note))
            {
                note.Date = DateTime.Now;
                App.NotesCollection.Add(note);
            }
            await Navigation.PopAsync();
        }
    }
}
