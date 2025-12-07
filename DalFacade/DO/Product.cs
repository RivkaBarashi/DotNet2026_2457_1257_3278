using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DalFacede.DO
{
    public record Product(int Id, string productName, Category Category, double Price, int stock);

}
