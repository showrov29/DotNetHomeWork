using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task02.DBContext;

namespace Task02.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult ManageStudent()
        {
            Bishop_Entities db = new Bishop_Entities();
            var students = db.Students.ToList();
            return View(students);
        }

        [HttpPost]
        public ActionResult ManageStudent(Student student)
        {
            var db = new Bishop_Entities();
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("ManageStudent");
            }
            var students = db.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult ManageCourse()
        {
            Bishop_Entities db = new Bishop_Entities();
            var courses = db.Courses.ToList();
            return View(courses);
        }

        [HttpPost]
        public ActionResult ManageCourse(Cours course)
        {
            var db = new Bishop_Entities();
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("ManageCourse");
        }
    }
}