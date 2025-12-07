using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    internal record Product(int Id, string productName, Category Category, double Price, int stock);

}
