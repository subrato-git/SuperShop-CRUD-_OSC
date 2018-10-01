using SuperShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SuperShop.Repository
{
    public class ProductHelper
    {
        ProductDBContext productDB = new ProductDBContext();

        public List<Products> GetAllProducts()
        {
            return productDB.tProducts.ToList();
        }

        public void addProduct(Products p)
        {
            var guid = Guid.NewGuid().ToString();
            p.ProductId = guid; 
            productDB.tProducts.Add(p);
            productDB.SaveChanges();
        }

        public Products GetSingleProduct(string id)
        {
            Products p = new Products();
            p = productDB.tProducts.SingleOrDefault(c => c.ProductId.Equals(id));
            return p;
        }

        public Products SearchProduct(string name)
        {
            Products p = new Products();
            p = productDB.tProducts.SingleOrDefault(c => c.ProductName.Equals(name));
            return p;
        }

        public List<Products> SearchProductByName(string name)
        {
            return productDB.tProducts.Where(c => c.ProductName.Equals(name)).ToList();
        }

        public List<Products> SearchProductByCategory(string category)
        {
            return productDB.tProducts.Where(c => c.ProductCategory.Equals(category)).ToList();
        }

        public void EditProduct(Products p)
        {
            productDB.tProducts.AddOrUpdate(p);
            productDB.SaveChanges();
        }

        public void DeleteProduct (string id)
        {
            try
            {
                var p = new Products { ProductId = id };
                productDB.tProducts.Attach(p);
                productDB.tProducts.Remove(p);
                productDB.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}