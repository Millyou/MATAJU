using System.Windows;
using System.Windows.Navigation;
using Matau.Models;
namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Uri("home_page.xaml", UriKind.Relative));

            LoginReqDto username = new LoginReqDto();
            userName.Text = username.Name;
           
        }

        private void lodingBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("ProgressStatus.xaml", UriKind.Relative));
            
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            // 로그인 창으로 이동
            Loginwin loginwin = new Loginwin();
            loginwin.Show();
            this.Close();
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("HelpDesk.xaml", UriKind.Relative));
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            // MainPage.xaml로 이동
            MainFrame.Navigate(new Uri("home_page.xaml", UriKind.Relative));
        }

        private void salesBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Sales.xaml", UriKind.Relative));
        }
    }
}