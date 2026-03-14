using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class ProductImplementation : IProduct
    {
        public int Create(Product item)
        {
            throw new DalIsExistException("Product not create");
        }

        public void Delete(int id)
        {
            throw new DalIsExistException("Product not delete");
        }

        public Product? Read(int id)
        {
            throw new DalIsExistException("Product not read");
        }

        public Product? Read(Func<Product, bool> filter)
        {
            throw new DalIsExistException("Product not read");
        }

        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            throw new DalIsExistException("Product not readall");
        }

        public void Update(Product item)
        {
            throw new DalIsExistException("Product not update");
        }
    }
}
