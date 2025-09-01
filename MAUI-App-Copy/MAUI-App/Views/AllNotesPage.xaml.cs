using Notes.Models;

namespace Notes.Views
{
    public partial class AllNotesPage : ContentPage
    {
        AllNotes allNotes = new AllNotes();

        public AllNotesPage()
        {
            InitializeComponent();
            BindingContext = allNotes;
        }

        private async void OnAddNoteClicked(object sender, EventArgs e)
        {
            var note = new Note();
            var notePage = new NotePage(note);
            await Navigation.PushAsync(notePage);
            // Only add if at least one field is filled
            if (!string.IsNullOrWhiteSpace(note.Title)
                || !string.IsNullOrWhiteSpace(note.Content)
                || !string.IsNullOrWhiteSpace(note.PhotoPath))
            {
                allNotes.Notes.Add(note);
            }
        }

        private async void OnViewNoteClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Note note)
            {
                var notePage = new NotePage(note);
                await Navigation.PushAsync(notePage);
            }
        }

        private void OnDeleteNoteClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Note note)
            {
                allNotes.Notes.Remove(note);
            }
        }
    }
}
