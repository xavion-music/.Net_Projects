using Notes.Models;

namespace Notes.Views
{
    public partial class AllNotesPage : ContentPage
    {
        public AllNotesPage()
        {
            InitializeComponent();
        }

        private async void OnAddNoteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotePage());
        }

        private async void OnEditNoteClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is Note note)
                await Navigation.PushAsync(new NotePage(note));
        }

        private async void OnDeleteNoteClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is Note note)
            {
                bool del = await DisplayAlert("Delete", "Delete this note?", "Yes", "No");
                if (del)
                    App.NotesCollection.Remove(note);
            }
        }
    }
}
