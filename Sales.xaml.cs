using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace WpfApp2
{
    public partial class Sales : Page
    {
        private int currentPage = 1;
        private int itemsPerPage = 4; // 한 페이지에 4개씩 표시
        private int totalPages = 1;

        public Sales()
        {
            InitializeComponent();
            LoadFilterOptions(); // 필터 옵션 로딩
        }

        private async void LoadFilterOptions()
        {
            // 더미 데이터를 사용하여 필터 옵션 설정 (나중에 주석 해제하여 실제 데이터베이스 연결)
            var filterOptions = await Task.FromResult(new List<string>
            {
                "필터 1",
                "필터 2",
                "필터 3",
                "필터 4"
            });

            FilterComboBox.ItemsSource = filterOptions;
            FilterComboBox.SelectedIndex = 0; // 첫 번째 항목을 기본 선택
        }

        private async void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            // 필터 값이 null일 경우 빈 문자열로 처리
            var filterValue = FilterComboBox.SelectedItem?.ToString() ?? string.Empty;

            // 더미 데이터를 반환하여 UI 테스트
            var products = await Task.FromResult(GetDummyProducts(filterValue));

            // 상품이 없을 경우 처리
            if (products == null || products.Count == 0)
            {
                ProductsWrapPanel.Children.Clear();
                ProductsWrapPanel.Children.Add(new TextBlock { Text = "상품 없음" });
            }
            else
            {
                // 상품을 화면에 표시
                DisplayProducts(products);
            }

            // 페이지 네비게이션 버튼 활성화/비활성화 설정
            UpdatePageNavigation();
        }

        private List<Product> GetDummyProducts(string filter)
        {
            // 더미 데이터 생성 (상품 4개씩)
            var products = new List<Product>();

            for (int i = 0; i < itemsPerPage; i++)
            {
                products.Add(new Product
                {
                    ImageUrl = "https://example.com/image" + (i + 1) + ".jpg",
                    Address = "주소 " + (i + 1)
                });
            }

            return products;
        }

        private void DisplayProducts(List<Product> products)
        {
            ProductsWrapPanel.Children.Clear();
            foreach (var product in products)
            {
                var productItem = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Width = 150,
                    Height = 200,
                    Margin = new Thickness(10)
                };

                var image = new Image
                {
                    Source = new BitmapImage(new Uri(product.ImageUrl ?? string.Empty)),
                    Width = 100,
                    Height = 100
                };
                var address = new TextBlock { Text = product.Address };

                // 상품 클릭 시 상세 페이지로 이동
                var productButton = new Button
                {
                    Content = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        Children = { image, address }
                    }
                };
                productButton.Click += (sender, e) => OnProductClicked(product);

                productItem.Children.Add(productButton);
                ProductsWrapPanel.Children.Add(productItem);
            }
        }

        private void OnProductClicked(Product product)
        {
            // 상세 화면으로 이동
            var productDetailPage = new ProductDetailPage(product);
            this.NavigationService.Navigate(productDetailPage);
        }

        private void UpdatePageNavigation()
        {
            // 현재 페이지 번호 갱신
            PageNumberTextBlock.Text = $"Page {currentPage} / {totalPages}";

            // 네비게이션 버튼 상태 갱신
            PreviousPageButton.IsEnabled = currentPage > 1;
            NextPageButton.IsEnabled = currentPage < totalPages;
        }

        private void OnPreviousPageButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                OnSearchButtonClick(sender, e);
            }
        }

        private void OnNextPageButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                OnSearchButtonClick(sender, e);
            }
        }

        private void OnFilterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 필터 선택 변경 시, 검색 버튼 클릭
            OnSearchButtonClick(sender, e);
        }
    }

    public class Product
    {
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }
    }
}
