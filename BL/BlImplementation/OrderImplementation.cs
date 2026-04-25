using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private DalFacade.DalApi.IDal _dal = DalApi.Factory.Get;

        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int amount)
        {
            if (order == null)
                throw new BO.BlInvalidInputException("Order is null");

            var doProduct = _dal.Product.Read(productId)
                ?? throw new BO.BlDoesNotExistException("Product not found");

            order.Products ??= new List<BO.ProductInOrder>();

            var productInOrder = order.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (productInOrder == null)
            {
                if (amount <= 0)
                    throw new BO.BlInvalidInputException("Invalid amount");

                productInOrder = new BO.ProductInOrder
                {
                    ProductId = doProduct.Id,
                    ProductName = doProduct.ProductName,
                    BasePrice = doProduct.Price ?? 0,
                    Amount = amount,
                    TotalPrice = 0,
                    Sales = new List<BO.SaleInProduct>()
                };

                order.Products.Add(productInOrder);
            }
            else
            {
                if (productInOrder.Amount + amount <= 0)
                    throw new BO.BlInvalidInputException("Invalid amount");

                productInOrder.Amount += amount;
            }

            SearchSaleForProduct(productInOrder, order.IsFavorite);

            CalcTotalPriceForProduct(productInOrder);

            CalcTotalPrice(order);

            return productInOrder.Sales ?? new List<BO.SaleInProduct>();
        }

        public void SearchSaleForProduct(BO.ProductInOrder product, bool isFavorite)
        {
            var now = DateTime.Now;

            product.Sales = _dal.Sale.ReadAll()
                .Where(s =>
                    s.ProductId == product.ProductId &&
                    (s.StartSale == null || s.StartSale <= now) &&
                    (s.EndSale == null || s.EndSale >= now) &&
                    product.Amount >= s.QuantityRequier &&
                    (isFavorite || s.IsSaleToCustomer))
                .Select(s => new BO.SaleInProduct
                {
                    SaleId = s.Id,
                    QuantityForSale = s.QuantityRequier,
                    Price = s.SalePrice ?? 0,
                    ForEveryone = s.IsSaleToCustomer
                })
                .OrderBy(s => s.Price)
                .ToList();
        }

        public void CalcTotalPriceForProduct(BO.ProductInOrder product)
        {
            double total = 0;
            int count = product.Amount;

            var usedSales = new List<BO.SaleInProduct>();

            if (product.Sales != null)
            {
                foreach (var sale in product.Sales.OrderBy(s => s.Price))
                {
                    if (count <= 0)
                        break;

                    if (count < sale.QuantityForSale)
                        continue;

                    int times = count / sale.QuantityForSale;

                    if (times > 0)
                    {
                        total += times * sale.Price;
                        count -= times * sale.QuantityForSale;
                        usedSales.Add(sale);
                    }
                }
            }

            total += count * product.BasePrice;

            product.TotalPrice = total;
            product.Sales = usedSales;
        }

        public void CalcTotalPrice(BO.Order order)
        {
            order.TotalPrice =
                order.Products?.Sum(p => p.TotalPrice) ?? 0;
        }

        public void DoOrder(BO.Order order)
        {
            if (order.Products == null)
                return;

            foreach (var item in order.Products)
            {
                var product = _dal.Product.Read(item.ProductId)
                    ?? throw new BO.BlDoesNotExistException("Product not found");

                if (product.Stock < item.Amount)
                    throw new BO.BlInvalidInputException("Not enough stock");

                var updated = product with
                {
                    Stock = product.Stock - item.Amount
                };

                _dal.Product.Update(updated);
            }
        }
    }
}