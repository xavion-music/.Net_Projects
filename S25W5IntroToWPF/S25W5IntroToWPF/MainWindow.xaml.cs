using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S25W5IntroToWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            MessageBox.Show("Hello "+ name, "Message", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
                MessageBox.Show("Yes Clicked");
            else
                MessageBox.Show("No Clicked");
        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtName.Background = Brushes.LightBlue;
        }

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            txtName.Background = Brushes.White;
        }

        private void btnGridExamples_Click(object sender, RoutedEventArgs e)
        {
            GridExample gridEx = new GridExample();
            gridEx.ShowDialog();
        }
    }
}