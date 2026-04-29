using BlApi;

namespace BlImplementation
{
    internal class Bl : IBl
    {
        public ICustomer Customer => new CustomerImplementation();
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
<<<<<<< HEAD
=======
        public IOrder Order => new OrderImplementation();

>>>>>>> ba9648521294c3265027d0de12859a2717a89e80
    }
}