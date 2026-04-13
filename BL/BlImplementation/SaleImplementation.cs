using BO;


namespace BlImplementation
{
    // האם זה יורש מBO או מDO?
    internal class SaleImplementation:Sale
    {
        private DalApi.IDal _dal = (DalApi.IDal)DalApi.Factory.Get;
    }
}
