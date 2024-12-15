using System;
using System.Collections.Generic;
using System.IO;
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
            // 더미 데이터를 사용하여 필터 옵션 설정
            var filterOptions = await Task.FromResult(new List<string>
            {
                "",
                "강원도",
                "경기도",
                "경상남도",
                "경상북도",
                "광주광역시",
                "대구광역시",
                "대전광역시",
                "부산광역시",
                "서울특별시",
                "울산광역시",
                "인천광역시",
                "전라남도",
                "전라북도",
                "충청남도",
                "충청북도"
            });


            FilterComboBox.ItemsSource = filterOptions;
            FilterComboBox.SelectedIndex = 0; // 첫 번째 항목을 기본 선택
        }

        private async void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            // 필터 값이 null일 경우 빈 문자열로 처리
            var filterValue = FilterComboBox.SelectedItem?.ToString() ?? string.Empty;

            // 지정된 폴더에서 이미지를 가져와 상품 데이터 생성
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
            // API에서 받아온 데이터를 기반으로 필터링 작업 수행
            var apiProducts = ApiProduct.Products;

            // 필터 적용: Province 또는 Add(주소)에 필터 조건이 포함된 경우만 선택
            var filteredProducts = apiProducts
                .Where(p => string.IsNullOrEmpty(filter) ||
                            (p.Province?.Contains(filter) == true || p.Add?.Contains(filter) == true))
                .ToList();

            var products = new List<Product>();
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, filteredProducts.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                var apiProduct = filteredProducts[i];
                products.Add(new Product
                {
                    Id = apiProduct.Id ?? 0, // Null 방지
                    Address = apiProduct.Add ?? "주소 없음",
                    Province = apiProduct.Province ?? "도시/도 없음",
                    ImageUrl = $"C:/Procject/Mataju/Mataju/Resources/{apiProduct.Id}-1.jpeg" // ID 기반 이미지 URL
                });
            }

            totalPages = (int)Math.Ceiling((double)filteredProducts.Count / itemsPerPage);

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

                // 로컬 이미지 로드
                var imageSource = string.IsNullOrEmpty(product.ImageUrl)
                    ? new BitmapImage() // 기본 빈 이미지
                    : new BitmapImage(new Uri(product.ImageUrl, UriKind.Absolute));

                var image = new Image //이미지 사이즈
                {
                    Source = imageSource,
                    Width = 100,
                    Height = 100
                };

                var address = new TextBlock { Text = ApiProduct.Province + " " + ApiProduct.Add ?? "주소 없음" };

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
        public string? ImageUrl { get; set; } // 이미지링크
        public string? Address { get; set; } //주소
        public string? Province { get; set; } // 도시/도
        public int Id { get; set; } //지점 고유번호
    }


}
