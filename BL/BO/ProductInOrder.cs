using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    internal class ProductInOrder
    {
        int ProductInOrderId;
        string ProductName;
        double basePrice;
        int countInOrder;
        List<SaleInProduct> SaleInProduct;
        double sum;

    }
}
