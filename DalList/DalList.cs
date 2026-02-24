using DO;

using DalApi;
using DalFacade.DalApi;
<<<<<<< HEAD

namespace Dal
{
    public class DalList:IDal
=======
using System.ComponentModel;

namespace Dal
{
    internal sealed class DalList : IDal
>>>>>>> f8da3f0 (part7)
    {
        public ICustomer Customer => new CustomerImplementation();
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
<<<<<<< HEAD


=======
        private  readonly DalList instance=new DalList();
        public DalList Instance { get { return instance; } }

        private DalList()
        {

        }
>>>>>>> f8da3f0 (part7)
    }
}
