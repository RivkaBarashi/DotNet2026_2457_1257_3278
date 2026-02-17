using DO;
using DalApi;
using DalFacade.DalApi;

namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        var q = DataSource.Products.Any(c => c.Id == item.Id);
        if (q)
            throw new DalIsExistException("Customer Exist ");

        else
            //חיב לקבל משתנה מבצע עם מזהה קיים
            DataSource.Products.Add(item);  
           
        return item.Id;
        
    }

    public void Delete(int id)
    {

        var q = DataSource.Products.Single(c=>c.Id==id);
        if(q is null)
            throw new DalIsNotExistException("this sale not found");
        else
        {
            DataSource.Products.Remove(q);
        }

    }

    public Product? Read(int id)
    {
        var q = DataSource.Products.First(c => c.Id == id);
        if (q is null)
            throw new DalIsNotExistException("id prodact not exist");
        else
            return q;
    }
    public Product? Read(Func<Product, bool> filter)
    {
        var q = DataSource.Products.First(c => filter(c));
        if (q is null)
            throw new DalIsNotExistException("id prodact not exist");
        else
            return q;
    }

     public List<Product?> ReadAll(Func<Product, bool>? filter)
    {
        if (filter == null)
            return new List<Product?>(DataSource.Products);
            var q = DataSource.Products.Where(c => filter(c));
        return DataSource.Products;

    }

    public void Update(Product item)
    {
        var q= DataSource.Products.Single(c=>c.Id==item.Id);
        if (q is null)
            throw new DalIsNotExistException("No operation found with this ID");
        else {
            DataSource.Products.Remove(q);
            DataSource.Products.Add(item);
        }

       
        
    }

    
}