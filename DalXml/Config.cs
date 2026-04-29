<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> ba9648521294c3265027d0de12859a2717a89e80
using System.Xml.Linq;

namespace DalXml
{
    internal static class Config
    {
<<<<<<< HEAD
        //const string path = @"..\..\..\xml\data-config.xml";
        private static readonly string path =
        Path.Combine(AppContext.BaseDirectory, "xml", "data-config.xml");
        const string PRODUCTID = "productId";
        const string SALEID = "saleId";
        //static XElement dataConfigXml = XElement.Load(path);
=======
        private static readonly string path =
            Path.Combine(AppContext.BaseDirectory, "xml", "data-config.xml");
        const string PRODUCTID = "productId";
        const string SALEID = "saleId";
>>>>>>> ba9648521294c3265027d0de12859a2717a89e80
        static XElement dataConfigXml = LoadConfig();

        private static XElement LoadConfig()
        {
<<<<<<< HEAD
            Console.WriteLine($"Config path: {path}");
            Console.WriteLine($"Exists: {File.Exists(path)}");

            return XElement.Load(path);
        }
        private static int ProductId = int.Parse(dataConfigXml.Element(PRODUCTID).Value);
        private static int myVar; //מיותר?!

=======
            if (!File.Exists(path))
                throw new FileNotFoundException($"data-config.xml file was not found at '{path}'", path);

            return XElement.Load(path);
        }

        private static int ProductId = int.Parse(dataConfigXml.Element(PRODUCTID)!.Value);
>>>>>>> ba9648521294c3265027d0de12859a2717a89e80

        public static int GetProductId
        {
            get
            {
                ProductId++;
<<<<<<< HEAD
                dataConfigXml.Element(PRODUCTID).SetValue(ProductId.ToString());
=======
                dataConfigXml.Element(PRODUCTID)!.SetValue(ProductId.ToString());
>>>>>>> ba9648521294c3265027d0de12859a2717a89e80
                dataConfigXml.Save(path);
                return ProductId;
            }
        }

<<<<<<< HEAD

        private static int SaleId = int.Parse(dataConfigXml.Element(SALEID).Value);
=======
        private static int SaleId = int.Parse(dataConfigXml.Element(SALEID)!.Value);
>>>>>>> ba9648521294c3265027d0de12859a2717a89e80

        public static int GetSaleId
        {
            get
            {
                SaleId++;
<<<<<<< HEAD
                dataConfigXml.Element(SALEID).SetValue(SaleId.ToString());
=======
                dataConfigXml.Element(SALEID)!.SetValue(SaleId.ToString());
>>>>>>> ba9648521294c3265027d0de12859a2717a89e80
                dataConfigXml.Save(path);
                return SaleId;
            }
        }
<<<<<<< HEAD



    }
}
=======
    }
}
>>>>>>> ba9648521294c3265027d0de12859a2717a89e80
