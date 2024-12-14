using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class ProgressStatus : Page
    {
        public ProgressStatus()
        {
            InitializeComponent();
        }

        // 첫 번째 조회 버튼 클릭 이벤트
        private async void SalesInquirybtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var salesData = await FetchDataFromApi("https://example.com/api/sales");
                SalesStatusGrid1.ItemsSource = salesData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 불러오는 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // 두 번째 조회 버튼 클릭 이벤트
        private async void PurchaseInquiry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var purchaseData = await FetchDataFromApi("https://example.com/api/purchase");
                SalesStatusGrid2.ItemsSource = purchaseData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 불러오는 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // API에서 데이터 가져오기
        private async Task<List<DataGridItem>> FetchDataFromApi(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<DataGridItem>>(json) ?? new List<DataGridItem>();
                }
                else
                {
                    throw new Exception($"API 호출 실패: {response.StatusCode}");
                }
            }
        }
    }

    // DataGrid에 바인딩할 데이터 모델 클래스
    public class DataGridItem
    {
        public int UniqueId { get; set; }
        public string? Region { get; set; }
        public string? Model { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
    }
}