using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using Matau.Models;
using WpfApp2;

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
            MainFrame.Navigate(new Uri("home_page.xaml", UriKind.Relative));
        }

        private async void salesBtn_Click(object sender, RoutedEventArgs e)
        {
            using var httpClient = new HttpClient { BaseAddress = new Uri(IpAdd.IP) };

            try
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiToken.Token}");
                httpClient.DefaultRequestHeaders.Add("Accept", "*/*");

                HttpResponseMessage response = await httpClient.GetAsync("api/House/all");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var cityInfos = JsonSerializer.Deserialize<List<ProductData>>(responseBody, options);


                    if (cityInfos != null && cityInfos.Count > 0)
                    {
                        ApiProduct.Products = cityInfos;

                        var message = new StringBuilder();
                        foreach (var city in cityInfos)
                        {
                            message.AppendLine(
                                $"ID: {city.Id}, 주소: {city.Add}, 도시: {city.Province}, " +
                                $"소형 가격: {city.PriceS}, 중형 가격: {city.PriceM}, 대형 가격: {city.PriceL}"
                            );
                        }

                        MessageBox.Show(message.ToString(), "데이터 수신 성공", MessageBoxButton.OK, MessageBoxImage.Information);
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
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"네트워크 요청 중 오류 발생: {ex.Message}", "네트워크 오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"예기치 않은 오류 발생: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
    
    public class ProductData
    {
        public int? Id { get; set; }
        public string? Add { get; set; } // 주소
        public string? Province { get; set; } // 도시/도
        public int? PriceS { get; set; } // 소형 가격
        public int? PriceM { get; set; } // 중형 가격
        public int? PriceL { get; set; } // 대형 가격
    }

}
