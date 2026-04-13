
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Sale
    {
       

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityRequier { get; set; }
        public double SalePrice { get; set; }
        public DateTime StartSale { get; set; }
        public DateTime EndSale { get; set; }
        public Sale() { }
        public Sale(int id, int productId, int quantityRequier, double salePrice, DateTime startSale, DateTime endSale)
        {
            Id = id;
            ProductId = productId;
            QuantityRequier =quantityRequier;
            SalePrice = salePrice;
            StartSale = startSale;
            EndSale = endSale;
        }
    }
}
