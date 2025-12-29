using DO;
using DalApi;

namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        foreach (Product i in DataSource.Products)
        {
            if (item.Id == i.Id)
                throw new Exception("There is a product with this code");
        }
        //חיב לקבל משתנה מבצע עם מזהה קיים
        DataSource.Products.Add(item);
        return item.Id;
    }

    public void Delete(int id)
    {
        foreach (Product item in DataSource.Products)
        {
            if (item.Id == id)
            {
                DataSource.Products.Remove(item);
                return;
            }
        }
        throw new Exception("this sale not found");
    }

    public Product? Read(int id)
    {
        foreach (Product item in DataSource.Products)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }

    public IEnumerable<Product?> ReadAll()
    {
        return DataSource.Products;
    }

    public void Update(Product item)
    {
        foreach (Product i in DataSource.Products)
        {
            if (item.Id == i.Id)
            {
                DataSource.Products.Remove(i);
                DataSource.Products.Add(item);
                return;
            }
        }
        throw new Exception("No operation found with this ID");
    }
}