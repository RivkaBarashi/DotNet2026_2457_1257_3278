using DalApi; 
using DO;     

namespace DelTest
{
    public static class Initialization
    {
        private static ICustomer s_dalCustomer;
        private static IProduct s_dalProduct;
        private static ISale s_dalSale;

        private static void CreateCustomers()
        {
            var customer1 = new Customer { Id = 1, CustomerName = "Rivka", Adress = "Bnebrak", Phone = "0501234567" };
            var customer2 = new Customer { Id = 2, CustomerName = "Dana", Adress = "Jerusalem", Phone = "0529876543" };

            s_dalCustomer.Create(customer1);
            s_dalCustomer.Create(customer2);
        }

        private static void CreateProducts()
        {
            var product1 = new Product { Id = 100, ProductName = "Lipstick", Category = Categries.Spices, Price = 25.0, Stock = 10 };
            var product2 = new Product { Id = 101, ProductName = "Eyeshadow", Category = Categries.Frozens, Price = 40.0, Stock = 5 };

            s_dalProduct.Create(product1);
            s_dalProduct.Create(product2);
        }

        private static void CreateSales()
        {
            var sale1 = new Sale { Id = 1, ProductId = 100, QuantityRequier = 2, SalePrice = 20.0, IsSaleToCustomer = true, StartSale = DateTime.Today, EndSale = DateTime.Today.AddDays(7) };
            var sale2 = new Sale { Id = 2, ProductId = 101, QuantityRequier = 1, SalePrice = 35.0, IsSaleToCustomer = true, StartSale = DateTime.Today, EndSale = DateTime.Today.AddDays(7) };

            s_dalSale.Create(sale1);
            s_dalSale.Create(sale2);
        }

        public static void Initialize(ICustomer dalCustomer, IProduct dalProduct, ISale dalSale)
        {
            // שמירת הממשקים בשדות סטטיים
            s_dalCustomer = dalCustomer;
            s_dalProduct = dalProduct;
            s_dalSale = dalSale;

            // אתחול הרשימות
            CreateCustomers();
            CreateProducts();
            CreateSales();
        }




    }
}
