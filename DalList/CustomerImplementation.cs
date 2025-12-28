using DO;
using DalApi;

namespace Dal;

public class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        foreach (Customer i in DataSource.Customers)
        {
            if (item.Id == i.Id)
                throw new Exception("exist project with this code");
        }
        //חיב לקבל משתנה מבצע עם מזהה קיים
        DataSource.Customers.Add(item);
        return item.Id;
    }

    public void Delete(int id)
    {
        foreach (Customer item in DataSource.Customers)
        {
            if (item.Id == id)
            {
                DataSource.Customers.Remove(item);
                return;
            }
        }
        throw new Exception("this sale not found");
    }

    public Customer? Read(int id)
    {
        foreach (Customer item in DataSource.Customers)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }

    public IEnumerable<Customer?> ReadAll()
    {
        return DataSource.Customers;
    }

    public void Update(Customer item)
    {
        foreach (Customer i in DataSource.Customers)
        {
            if (item.Id == i.Id)
            {
                DataSource.Customers.Remove(i);
                DataSource.Customers.Add(item);
                return;
            }
        }
        throw new Exception("לא נמצא מבצע עם מזהה זה");
    }
}