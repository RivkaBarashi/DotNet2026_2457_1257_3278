using DO;

using DalApi;
using DalFacade.DalApi;



namespace Dal
{
    internal sealed class DalList : IDal

    {
        public ICustomer Customer => new CustomerImplementation();
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();

        private  readonly DalList instance=new DalList();
        public DalList Instance { get { return instance; } }

        private DalList()
        {

        }

    }
}
