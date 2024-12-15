using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using Matau.Models;
using System.Runtime;
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

        private async void salesBtn_Click(object sender, RoutedEventArgs e)
        {
            using var httpClient = new HttpClient { BaseAddress = new Uri("http://3.38.255.138/dev/") };

            try
            {
                // Authorization 헤더 설정
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiToken.Token}");
                httpClient.DefaultRequestHeaders.Add("Accept", "*/*");

                // GET 요청 보내기
                HttpResponseMessage response = await httpClient.GetAsync("api/House/all");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // JSON 데이터를 List<ApiProduct>로 역직렬화
                    var cityInfos = JsonSerializer.Deserialize<List<ApiProduct>>(responseBody);

                    if (cityInfos != null && cityInfos.Count > 0)
                    {
                        // 디버깅 데이터 출력
                        foreach (var city in cityInfos)
                        {
                            Console.WriteLine($"ID: {city.Id}, 주소: {city.Add}, 도시: {city.Province}, PriceS: {city.PriceS}, PriceM: {city.PriceM}, PriceL: {city.PriceL}");
                        }

                        MessageBox.Show("데이터 수신 성공! 상품 화면으로 이동합니다.", "성공", MessageBoxButton.OK, MessageBoxImage.Information);

                        MainFrame.Navigate(new Uri("Sales.xaml", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("받아온 데이터가 없습니다.", "정보", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"요청 실패: {response.StatusCode}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public class ApiProduct
        {
            public int? Id { get; set; }
            public string? Add { get; set; } // 주소
            public string? Province { get; set; } // 도시/도
            public int? PriceS { get; set; } // 소형 가격
            public int? PriceM { get; set; } // 중형 가격
            public int? PriceL { get; set; } // 대형 가격
            public int? test { get; set; } // 대형 가격 test
        }

    }

}
    
