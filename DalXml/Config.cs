using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DalXml
{
    internal static class Config
    {
        const string path = @"xml\data-config.xml";
        const string PRODUCTID = "productId";
        const string SALEID = "saleId";
        static XElement dataConfigXml = XElement.Load(path);
        private static int ProductId = int.Parse(dataConfigXml.Element(PRODUCTID).Value);
        private static int myVar; //מיותר?!


        public static int GetProductId
        {
            get
            {
                ProductId++;
                dataConfigXml.Element(PRODUCTID).SetValue(ProductId.ToString());
                dataConfigXml.Save(path);
                return ProductId;
            }
        }


        private static int SaleId = int.Parse(dataConfigXml.Element(SALEID).Value);

        public static int GetSaleId
        {
            get
            {
                SaleId++;
                dataConfigXml.Element(SALEID).SetValue(SaleId.ToString());
                dataConfigXml.Save(path);
                return SaleId;
            }
        }
    }
}