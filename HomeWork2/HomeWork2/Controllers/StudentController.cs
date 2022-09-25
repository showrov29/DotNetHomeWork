using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWork2.Models;

namespace HomeWork2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Profile()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Profile(Student student)
        {
            if (ModelState.IsValid)
            {
                RedirectToAction("Home", "Index");
            }

            return View(student);
        }
    }
}