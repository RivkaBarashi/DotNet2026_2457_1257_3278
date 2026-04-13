using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class ProductImplementation:Product
    {
        private DalApi.IDal _dal = (DalApi.IDal)DalApi.Factory.Get;

    }
}
