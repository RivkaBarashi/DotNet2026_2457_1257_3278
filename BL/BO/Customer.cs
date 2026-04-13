
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Customer
    {
       
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public Customer() { }
        public Customer(int id, string customerName, string adress, string phone)
        {
            Id = id;
            CustomerName = customerName;
            Adress = adress;
            Phone = phone;
        }
    }
}
