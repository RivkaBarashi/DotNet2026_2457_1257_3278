using System.Xml.Linq;

namespace DalXml
{
    internal static class Config
    {
        private static readonly string path =
            Path.Combine(AppContext.BaseDirectory, "xml", "data-config.xml");
        const string PRODUCTID = "productId";
        const string SALEID = "saleId";
        static XElement dataConfigXml = LoadConfig();

        private static XElement LoadConfig()
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"data-config.xml file was not found at '{path}'", path);

            return XElement.Load(path);
        }

        public static int GetProductId
        {
            get
            {
                int currentId = int.Parse(dataConfigXml.Element(PRODUCTID)!.Value);
                currentId++;
                dataConfigXml.Element(PRODUCTID)!.SetValue(currentId.ToString());
                dataConfigXml.Save(path);
                return currentId;
            }
        }

        public static int GetSaleId
        {
            get
            {
                int currentId = int.Parse(dataConfigXml.Element(SALEID)!.Value);
                currentId++;
                dataConfigXml.Element(SALEID)!.SetValue(currentId.ToString());
                dataConfigXml.Save(path);
                return currentId;
            }
        }
    }
}
