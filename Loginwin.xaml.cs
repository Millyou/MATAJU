using System.Windows;
using System.Windows.Controls;
using Matau.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using SlackAPI;
using System.ComponentModel;


namespace WpfApp2
{
    public partial class Loginwin : Window
    {
        public Loginwin()
        {
            InitializeComponent();
        }
        
        
        // 로그인 버튼 클릭 이벤트
        private async void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            // ID와 비밀번호 가져오기
            ApiToken.UserId = nameText.Text;
            ApiToken.UserPw = pwText.Password;

            using var httpClient = new HttpClient { BaseAddress = new Uri("http://3.38.255.138/dev/") };

            try
            {
                var id_pw = new { name = ApiToken.UserId, password = ApiToken.UserPw };

                // JSON 직렬화
                string jsonContent = JsonSerializer.Serialize(id_pw);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // API 요청 보내기
                HttpResponseMessage response = await httpClient.PostAsync("api/User/login", httpContent);


                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // JSON 파싱
                    var responseData = JsonSerializer.Deserialize<JsonDocument>(responseBody);
                    if (responseData != null && responseData.RootElement.TryGetProperty("token", out var tokenElement))
                    {
                        ApiToken.Token = tokenElement.GetString();
                        Console.WriteLine($"Token: {ApiToken.Token}");
                        MessageBox.Show(ApiToken.Token);
                        // UI 업데이트
                        MessageBox.Show("로그인 성공!", "성공", MessageBoxButton.OK, MessageBoxImage.Information);

                        // 다음 화면으로 이동
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("로그인 실패: 유효한 토큰을 받지 못했습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"로그인 실패: {response.StatusCode}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"로그인 중 오류 발생: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 회원가입 버튼 클릭 이벤트
        private void signBtn_Click(object sender, RoutedEventArgs e)
        {
            Signwin sign = new Signwin();
            sign.Show();
        }

        private void ME_Player_MediaEnded(object sender, RoutedEventArgs e)
        {

        }

        private void ME_Player_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }

    public static class ApiToken
    {
        public static string? Token { get; set; }
        public static string? UserId { get; set; }
        public static string? UserPw { get; set; }
    }
}
