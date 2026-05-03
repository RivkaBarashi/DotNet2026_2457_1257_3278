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

        private static int ProductId = int.Parse(dataConfigXml.Element(PRODUCTID)!.Value);

        public static int GetProductId
        {
            get
            {
                ProductId++;
                dataConfigXml.Element(PRODUCTID)!.SetValue(ProductId.ToString());
                dataConfigXml.Save(path);
                return ProductId;
            }
        }

        private static int SaleId = int.Parse(dataConfigXml.Element(SALEID)!.Value);

        public static int GetSaleId
        {
            get
            {
                SaleId++;
                dataConfigXml.Element(SALEID)!.SetValue(SaleId.ToString());
                dataConfigXml.Save(path);
                return SaleId;
            }
        }
    }
}
