using DalApi;
using DalFacade.DalApi;
using DO;
using System.Reflection;
using System.Xml.Linq;

using Tools;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    private static readonly string path = Path.Combine(AppContext.BaseDirectory, "xml", "Customers.xml");

    private XElement LoadXml()
    {
        if (!File.Exists(path))
            return new XElement("Customers");
        return XElement.Load(path);
    }

    private void SaveXml(XElement xml)
    {
        xml.Save(path);
    }

    private Customer XmlToCustomer(XElement x)
    {
        return new Customer
        {
            Id = int.Parse(x.Element("Id")!.Value),
            CustomerName = x.Element("CustomerName")!.Value,
            Address = x.Element("Address")?.Value,
            Phone = x.Element("Phone")?.Value
        };
    }

    private XElement CustomerToXml(Customer c)
    {
        return new XElement("Customer",
            new XElement("Id", c.Id),
            new XElement("CustomerName", c.CustomerName),
            new XElement("Address", c.Address),
            new XElement("Phone", c.Phone)
        );
    }

    public int Create(Customer item)
    {
        LogManager.WriteToLog("Start creating customer", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        var xml = LoadXml();

        if (xml.Elements("Customer").Any(c => int.Parse(c.Element("Id")!.Value) == item.Id))
            throw new DalIsExistException("Customer already exists");

        xml.Add(CustomerToXml(item));
        SaveXml(xml);

        LogManager.WriteToLog("Finished creating customer", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        return item.Id;
    }

    public Customer? Read(int id)
    {
        LogManager.WriteToLog("Start reading customer by ID", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        var xml = LoadXml();

        var customerElement = xml.Elements("Customer").FirstOrDefault(c => int.Parse(c.Element("Id")!.Value) == id);

        if (customerElement == null)
            throw new DalIsNotExistException("Customer not found");

        LogManager.WriteToLog("Finished reading customer by ID", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        return XmlToCustomer(customerElement);
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        LogManager.WriteToLog("Start reading customer by filter", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        if (filter == null)
            throw new ArgumentNullException(nameof(filter));

        var xml = LoadXml();

        var customerElement = xml.Elements("Customer")
            .Select(XmlToCustomer)
            .FirstOrDefault(filter);

        if (customerElement == null)
            throw new DalIsNotExistException("No customer matches filter");

        LogManager.WriteToLog("Finished reading customer by filter", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        return customerElement;
    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        LogManager.WriteToLog("Start reading all customers", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        var xml = LoadXml();

        var customers = xml.Elements("Customer").Select(XmlToCustomer);

        var result = (filter == null)
            ? customers
            : customers.Where(filter);

        LogManager.WriteToLog("Finished reading all customers", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        return result.Cast<Customer?>().ToList();
    }

    public void Update(Customer item)
    {
        LogManager.WriteToLog("Start updating customer", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        var xml = LoadXml();

        var customerElement = xml.Elements("Customer").FirstOrDefault(c => int.Parse(c.Element("Id")!.Value) == item.Id);

        if (customerElement == null)
            throw new DalIsNotExistException("Customer not found");

        customerElement.ReplaceWith(CustomerToXml(item));

        SaveXml(xml);

        LogManager.WriteToLog("Finished updating customer", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);
    }

    public void Delete(int id)
    {
        LogManager.WriteToLog("Start deleting customer", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);

        var xml = LoadXml();

        var customerElement = xml.Elements("Customer").FirstOrDefault(c => int.Parse(c.Element("Id")!.Value) == id);

        if (customerElement == null)
            throw new DalIsNotExistException("Customer not found");

        customerElement.Remove();

        SaveXml(xml);

        LogManager.WriteToLog("Finished deleting customer", GetType().FullName, MethodBase.GetCurrentMethod()!.Name);
    }
}
