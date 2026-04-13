


namespace BO
{
    public class Product
    {
      

        public int Id { get; set; }
        public string ProductName { get; set; }
        public Categries Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public Product() { }
        public Product(int id, string productName, Categries category, double price,int stock)
        {
            Id = id;
            ProductName = productName;
            Category = category;
            Price = price;
            Stock = stock;
        }
    }
}
