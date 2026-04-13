using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    // האם זה יורש מBO או מDO?
    internal class SaleImplementation:Sale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
    }
}
