using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
        public int Create(Sale item)
        {
            throw new DalIsExistException("Sale not creale");
        }

        public void Delete(int id)
        {
            throw new DalIsExistException("Sale not delete");
        }

        public Sale? Read(int id)
        {
            throw new DalIsExistException("Sale not Read");
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            throw new DalIsExistException("Sale not read");
        }

        public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            throw new DalIsExistException("Sale not Readall");
        }

        public void Update(Sale item)
        {
            throw new DalIsExistException("Sale not update");
        }
    }
}
