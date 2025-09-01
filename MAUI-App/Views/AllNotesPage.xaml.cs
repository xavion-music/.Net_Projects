using Notes.Models;

namespace Notes.Views
{
    public partial class AllNotesPage : ContentPage
    {
        AllNotes allNotes = new AllNotes();

        public AllNotesPage()
        {
            InitializeComponent();
            allNotes.LoadNotes();
            BindingContext = allNotes;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            allNotes.LoadNotes(); // Always reload notes when returning!
        }

        private async void OnAddNoteClicked(object sender, EventArgs e)
        {
            var note = new Note();
            var notePage = new NotePage(note);
            await Navigation.PushAsync(notePage);
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
                if (File.Exists(note.Filename))
                    File.Delete(note.Filename);
                allNotes.Notes.Remove(note);
            }
        }
    }
}
