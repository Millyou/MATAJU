using System.Configuration;
using System.Data;
using System.Windows;
using static System.Net.WebRequestMethods;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public static class IpAdd
    {
        public static string IP = "http://13.125.200.19/dev/";


    }

    public static class ApiProduct
    {
        public static int? Id { get; set; }
        public static string? Add { get; set; } // 주소
        public static string? Province { get; set; } // 도시/도
        public static int? PriceS { get; set; } // 소형 가격
        public static int? PriceM { get; set; } // 중형 가격
        public static int? PriceL { get; set; } // 대형 가격

        public static List<ProductData> Products { get; set; } = new List<ProductData>();
    }




}
