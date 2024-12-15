using System.Windows;
using System.Windows.Controls;
using Matau.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;



namespace WpfApp2
{
    public partial class Signwin : Window
    {
        string? pass1;
        string? pass2;
        public USER ViewModel { get; set; }

        public Signwin()
        {
            InitializeComponent();
            ViewModel = new USER();
            DataContext = ViewModel;

            
        }


        /// <summary>
        /// 1차 패스워드 업데이트시 가져오는 매서드
        /// </summary>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                this.pass1 = passwordBox.Password;
                
                
            }
        }


        /// <summary>
        /// 2차 패스워드 업데이트시 가져오는 매서드
        /// </summary>
        private void PasswordConfirmBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                this.pass2 = passwordBox.Password;
                
            }
        }


        /// <summary>
        /// 비번 일치 조회후 회원가입 매서드
        /// </summary>
        private async void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.pass1 == this.pass2)
            {
                // 1. SignReqDto 객체 생성 및 값 설정
                SignReqDto signReqDto = new SignReqDto
                {
                    Name = nameText_2.Text,
                    Password = pwText_2.Password,
                    Nickname = nickText_2.Text
                };

                // 2. HttpClient 객체 초기화
                using (HttpClient httpClient = new HttpClient())
                {

                    httpClient.BaseAddress = new Uri(IpAdd.IP);


                    try
                    {
                        // 3. SignReqDto 객체를 JSON으로 직렬화
                        string jsonContent = JsonSerializer.Serialize(signReqDto);

                        // 4. JSON 데이터를 HTTP 요청의 Content로 설정
                        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        // 5. POST 요청 보내기
                        HttpResponseMessage response = await httpClient.PostAsync("api/User/register", httpContent);


                        // 6. 응답 처리
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("회원가입이 완료 되었습니다.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("중복된 아이디가 있습니다.");
                            nameText_2.Text = "";
                            pwText_2.Password = "";
                            pwokText_2.Password = "";
                            nickText_2.Text = "";

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"오류 : {ex}"); ;

                    }
                    
                }
            }
            else MessageBox.Show("비밀번호가 일치하지 않습니다.");
                
            }

        /// <summary>
        /// 회원가입 취소 버튼
        /// </summary>
        private void noBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("회원가입을 취소 하였습니다.");
            this.Close();

        }
    }
}
