using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Zero_hunger2.DB;


namespace Zero_hunger2.Controllers
{
    public class ResturentController : Controller
    {
      
        // GET: Resturent
        [HttpGet]
        public ActionResult CollectRec(  )

        {
            var  id = 1;
            Zero_HungerEntities db = new Zero_HungerEntities();

            var x = (from c in db.Colleacts where c.ResId == id select c ).ToList();

            return View(x);
        }


        [HttpGet]
        public ActionResult CollEdit(int id)
        {


            return View();
        }

        [HttpPost]
        public ActionResult CollEdit(int id, Colleact c)
        {
            if (ModelState.IsValid)
            {
                Zero_HungerEntities db = new Zero_HungerEntities();
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("CollectRec");
            }
            return View(c);
            
        }


        [HttpGet]
        public ActionResult CollDelete(int id)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var res = db.Colleacts.Find(id);

            return View(res);
        }

        public ActionResult CollDelete(int id, Colleact c)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var rest = (from x in db.Colleacts where c.ResId == id select x).SingleOrDefault();
            db.Colleacts.Remove(rest);
            db.SaveChanges();


            return RedirectToAction("CollectRec");
        }


        [HttpGet]
        public ActionResult AddCollReq()
        {
            return View();

        }


        [HttpPost]
        public ActionResult AddCollReq(Colleact c)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            db.Colleacts.Add(c);
            db.SaveChanges();
            return RedirectToAction("Resturents");
        }

        [HttpGet]
        public ActionResult AcceptHistory()

        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var acc = db.Accepteds.ToList();

            return View(acc);
        }

        [HttpGet]
        public ActionResult AddAccept()
        {
            return View();

        }


        [HttpPost]
        public ActionResult AddAccept(Accepted rest)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            db.Accepteds.Add(rest);
            db.SaveChanges();
            return RedirectToAction("AcceptHistory");
        }


        [HttpGet]
        public ActionResult AcEdit(int id)
        {


            return View();
        }

        [HttpPost]
        public ActionResult AcEdit(int id, Accepted c)
        {
            if (ModelState.IsValid)
            {
                Zero_HungerEntities db = new Zero_HungerEntities();
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("AcceptHistory");
            }
            return View(c);

        }


        [HttpGet]
        public ActionResult AcDelete(int id)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var res = db.Accepteds.Find(id);

            return View(res);
        }

        public ActionResult AcDelete(int id, Colleact c)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var rest = (from x in db.Accepteds where c.ResId == id select x).SingleOrDefault();
            db.Accepteds.Remove(rest);
            db.SaveChanges();


            return RedirectToAction("AcceptHistory");
        }


        [HttpGet]
        public ActionResult AcDetails(int id)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var res = db.Accepteds.Find(id);

            return View(res);
        }





    }
}