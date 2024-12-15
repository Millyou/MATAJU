using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class ProductDetailPage : Page
    {
        private Product _product;

        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            _product = product;

            // 상품 정보 설정
            ProductAddress.Text = _product.Address;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            backBtn.Visibility = Visibility.Collapsed;

            MainFrame.Navigate(new Uri("Sales.xaml", UriKind.Relative));

            ProductAddress.Text = "";
        }
    }
}
