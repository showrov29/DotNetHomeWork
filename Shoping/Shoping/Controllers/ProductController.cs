using Shoping.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shoping.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new ECommerceEntities();
            var product = db.Products.ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {

            var db = new ECommerceEntities();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        List<Product> prodcuts = new List<Product>();

        public ActionResult Cart(int id)
        {
            var db = new ECommerceEntities();
            var product = (from p in db.Products where p.id == id select p).SingleOrDefault();
            if(Session["cart"]==null)
            {
               
                prodcuts.Add(product);
                string json = new JavaScriptSerializer().Serialize(prodcuts);
                Session["cart"] = json;
            }
            else
            {
                var cart = Session["cart"].ToString();
                var p = new JavaScriptSerializer().Deserialize<List<Product>>(cart);
                p.Add(product);

                string json = new JavaScriptSerializer().Serialize(p);
                Session["cart"] = json;
            }
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult ShowCart()
        {
            var cart = Session["cart"].ToString();
            var d = new JavaScriptSerializer().Deserialize<List<Product>>(cart);
            return View(d);
        }
        public ActionResult Delete()
        {
            return View();
        }
        

        public ActionResult ConfirmPurChase()
        {
            var db = new ECommerceEntities();
            var cart = Session["cart"].ToString();
            var d = new JavaScriptSerializer().Deserialize<List<Product>>(cart);
            foreach(var i in d)
            {
                db.Purchases.Add(i);
            }
            
         


        

            
            return RedirectToAction("Index");
        }




    }
}