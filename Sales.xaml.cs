using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            var filterOptions = await Task.FromResult(new List<string>
            {
                "",
                "강원도", "경기도", "경상남도", "경상북도", "광주광역시",
                "대구광역시", "대전광역시", "부산광역시", "서울특별시",
                "울산광역시", "인천광역시", "전라남도", "전라북도", "충청남도", "충청북도"
            });

            FilterComboBox.ItemsSource = filterOptions;
            FilterComboBox.SelectedIndex = 0; // 첫 번째 항목을 기본 선택
        }

        private async void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            var filterValue = FilterComboBox.SelectedItem?.ToString() ?? string.Empty;
            var products = await Task.FromResult(GetDummyProducts(filterValue));

            ProductsWrapPanel.Children.Clear();
            if (products == null || products.Count == 0)
            {
                ProductsWrapPanel.Children.Add(new TextBlock { Text = "상품 없음" });
            }
            else
            {
                DisplayProducts(products);
            }

            UpdatePageNavigation();
        }

        private List<Product> GetDummyProducts(string filter)
        {
            var apiProducts = ApiProduct.Products;

            // 필터링
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
                    Id = apiProduct.Id ?? 0,
                    Address = apiProduct.Add ?? "주소 없음",
                    Province = apiProduct.Province ?? "도시/도 없음"
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
                    Height = 100,
                    Margin = new Thickness(10)
                };

                var address = new TextBlock { Text = $"{product.Province} {product.Address}" };

                var productButton = new Button
                {
                    Content = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        Children = { address }
                    }
                };

                productButton.Click += (sender, e) => OnProductClicked(product);

                productItem.Children.Add(productButton);
                ProductsWrapPanel.Children.Add(productItem);
            }
        }

        private void OnProductClicked(Product product)
        {
            var productDetailPage = new ProductDetailPage(product);
            this.NavigationService.Navigate(productDetailPage);
        }

        private void UpdatePageNavigation()
        {
            PageNumberTextBlock.Text = $"Page {currentPage} / {totalPages}";
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
            OnSearchButtonClick(sender, e);
        }
    }

    public class Product
    {
        public string? Address { get; set; }
        public string? Province { get; set; }
        public int? Id { get; set; }
    }
}
