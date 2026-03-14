using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class CustomerImplementation : ICustomer
    {
        public int Create(Customer item)
        {
            throw new DalIsExistException("Customer not create");
        }

        public void Delete(int id)
        {
            throw new DalIsExistException("Customer not detete");
        }

        public Customer? Read(int id)
        {
            throw new DalIsExistException("Customer not read");
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            throw new DalIsExistException("Customer not read");
        }

        public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
        {
            throw new DalIsExistException("Customer not readall");
        }

        public void Update(Customer item)
        {
            throw new DalIsExistException("Customer not update");
        }
    }
}
