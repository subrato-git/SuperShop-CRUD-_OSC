using SuperShop.Models;
using SuperShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShop.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        ProductHelper productHelper = new ProductHelper();

        public ActionResult Index()
        {

            return View(productHelper.GetAllProducts());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products p)
        {
            productHelper.addProduct(p);
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            return View(productHelper.GetSingleProduct(id));
        }

        [HttpPost]
        public ActionResult Edit (Products p)
        {
            productHelper.EditProduct(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete (string id)
        {
            productHelper.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details (String id)

        {
            Products p = new Products();
            p = productHelper.GetSingleProduct(id);
            return View(p);
        }

        public ActionResult Search ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search (string searchBy, string ProductName)
        {
            System.Diagnostics.Debug.WriteLine(searchBy);
            //Console.Read();
            if (searchBy.Equals("Name"))
            {
                TempData["product"] = productHelper.SearchProductByName(ProductName);
                return RedirectToAction("SearchResult");
            }
            else if(searchBy.Equals("Category"))
            {
                TempData["product"] = productHelper.SearchProductByCategory(ProductName);
                return RedirectToAction("SearchResult");
            }
            else
            {
                return View();
            }
        }

        public ActionResult SearchResult ()
        {
            List<Products> p = (List<Products>)TempData["product"];
            return View(p);
        }
    }
}