
namespace Dal;
using DO;


internal static class DataSource
{
    internal static List<Customer?> Customers = new List<Customer?>();
    internal static List<Product?> Products = new List<Product?>();
    internal static List<Sale?> Sales = new List<Sale?>();
    internal static class Config
    {
        internal const int firstIdProduct = 100000;
        private static int productId = firstIdProduct;
        public static int GetProductId()
        {
            return productId++;
        }

        internal const int firstIdSale = 100;
        private static int saleId = firstIdSale;
        public static int GetSaleId()
        {
            return saleId++;
        }
    }


}