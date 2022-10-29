using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task02.DBContext;

namespace Task02.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Registration()
        {
            Bishop_Entities db = new Bishop_Entities();
            var students = db.Students.ToList();

            return View(students);
        }
        public ActionResult RegistrationPage(int id)
        {
            Bishop_Entities db = new Bishop_Entities();
            var student = db.Students.Find(id);
            var courseRecords = student.CourseStudents;

            var allCourses = db.Courses.ToList();
            var availableCourses = db.Courses.ToList();

            if(courseRecords.Count > 0)
            {
                foreach (var c in allCourses)
                {
                    foreach (var sc in courseRecords)
                    {
                        if (c.id == sc.courseId)
                        {
                            if (sc.marks < 60 || sc.grade == "W")
                            {
                                continue;
                            }
                            availableCourses.Remove(c);
                        }
                    }
                }
            }

            var eligibleCourses = new List<Cours>();

            //foreach (var c in availableCourses)
            //{
            //    foreach (var sc in courseRecords)
            //    {
            //        if (c.PreReq == 0 && !eligibleCourses.Contains(c))
            //        {
            //            eligibleCourses.Add(c);
            //        }
            //        else if (sc.courseId == c.PreReq && !eligibleCourses.Contains(c))
            //        {
            //            eligibleCourses.Add(c);
            //        }
            //    }
            //}


            if(courseRecords.Count==0)
            {
                foreach (var c in availableCourses)
                {
                    if (c.PreReq == 0 && !eligibleCourses.Contains(c))
                    {
                        eligibleCourses.Add(c);
                    }
                }
            }
            else
            {
                foreach (var sc in courseRecords)
                {
                    foreach (var c in availableCourses)
                    {
                        if (c.PreReq == 0 && !eligibleCourses.Contains(c))
                        {
                            eligibleCourses.Add(c);
                        }
                        else if (sc.courseId == c.PreReq && !eligibleCourses.Contains(c))
                        {
                            eligibleCourses.Add(c);
                        }
                    }
                }
            }

            TempData["studentId"] = student.id;
            return View(eligibleCourses);
        }

        [HttpPost]
        public ActionResult RegistrationConfirm(int[] courses, int studentId)
        {
            Bishop_Entities db = new Bishop_Entities();
            var courseStudents = db.CourseStudents.ToList();

            foreach (var c in courses)
            {
                CourseStudent cs = new CourseStudent();
                cs.studentId = studentId;
                cs.courseId = c;

                db.CourseStudents.Add(cs);
                db.SaveChanges();
            }

            return RedirectToAction("Registration");
        }
    }
}