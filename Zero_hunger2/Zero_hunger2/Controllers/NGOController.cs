using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_hunger2.DB;

namespace Zero_hunger2.Controllers
{
    public class NGOController : Controller
    {
        [HttpGet]
        public ActionResult Resturents()

        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var resturents = db.Resturents.ToList();

            return View(resturents);
        }

        [HttpGet]
        public ActionResult AddResturent()
        {
            return View();

        }


        [HttpPost]
        public ActionResult AddResturent(Resturent rest)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            db.Resturents.Add(rest);
            db.SaveChanges();
            return RedirectToAction("Resturents");
        }


        [HttpGet]
        public ActionResult ResDetails(int id)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var res = db.Resturents.Find(id);

            return View(res);
        }

        [HttpGet]
        public ActionResult ResEdit(int id)
        {


            return View();
        }

        [HttpPost]
        public ActionResult ResEdit(int id, Resturent res)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            db.Entry(res).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Resturents");
        }

        [HttpGet]
        public ActionResult ResDelete(int id)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var res = db.Resturents.Find(id);

            return View(res);
        }

        public ActionResult ResDelete(int id, Resturent res)
        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var rest = db.Resturents.Find(id);
            db.Resturents.Remove(rest);
            db.SaveChanges();


            return RedirectToAction("Resturents");
        }


        public ActionResult Employee()

        {
            Zero_HungerEntities db = new Zero_HungerEntities();
            var acc = db.Employees.ToList();

            return View(acc);
        }



    }
}