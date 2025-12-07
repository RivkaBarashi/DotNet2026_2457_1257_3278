using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DalFacede.DO

{
    public record Customer(int Id, string CustomerName, string Address, string PhoneNumber);

}
