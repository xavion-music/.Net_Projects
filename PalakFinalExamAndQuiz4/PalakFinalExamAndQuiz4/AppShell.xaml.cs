using KarandeepFinalExam.Views;

namespace KarandeepFinalExam
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NotePage), typeof(Views.NotePage));
        }
    }
}
