
using DO;
using DalApi;

namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        foreach (Sale i in DataSource.Sales)
        {
            if (item.Id == i.Id)
                throw new Exception("קיים מבצע בקוד זה");
        }
        //חיב לקבל משצנה מבצע עם מזהה קיים
        DataSource.Sales.Add(item);
        return item.Id;
    }

    public void Delete(int id)
    {
        foreach (Sale item in DataSource.Sales)
        {
            if (item.Id == id)
            {
                DataSource.Sales.Remove(item);
                return;
            }
        }
        throw new Exception("this sale not found");
    }

    public Sale? Read(int id)
    {
        foreach (Sale item in DataSource.Sales)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }

    public IEnumerable<Sale?> ReadAll()
    {
        return DataSource.Sales;
    }

    public void Update(Sale item)
    {
        foreach (Sale i in DataSource.Sales)
        {
            if (item.Id == i.Id)
            {
                DataSource.Sales.Remove(i);
                DataSource.Sales.Add(item);
                return;
            }
        }
        throw new Exception("לא נמצא מבצע עם מזהה זה");
    }
}