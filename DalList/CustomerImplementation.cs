using DO;
using DalApi;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        var q = DataSource.Customers.Any(c => c.Id == item.Id);
        if (q)
            throw new DalIsExistException("Customer Exist ");

        else
            //חיב לקבל משתנה מבצע עם מזהה קיים
            DataSource.Customers.Add(item);
        return item.Id;
    }

    public void Delete(int id)
    {
        var q = DataSource.Customers.Single(c => c.Id == id);
        if (q is null)
            throw new DalIsExistException("this sale not found");
        else
            DataSource.Customers.Remove(q);


    }

    public Customer? Read(int id)
    {
        var q = DataSource.Customers.First(c => c.Id == id);
        if (q is null)
            throw new DalIsNotExistException("Customer is not exist");
        else
            return q;

    }


    public IEnumerable<Customer?> ReadAll()
    {
        return DataSource.Customers;
    }

    public void Update(Customer item)
    {

        var q = DataSource.Customers.Single(c => c.Id == item.Id);
        if (q is null)
            throw new DalIsNotExistException(" Customer not exsist ");
        else
        {
            DataSource.Customers.Remove(q);
            DataSource.Customers.Add(item);
        }

    
    }
}