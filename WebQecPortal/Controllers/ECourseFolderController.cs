//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using WebQecPortal.Models;

//namespace WebQecPortal.Controllers
//{
//    public class ECourseFolderController : Controller
//    {
//        QecPortalEntities db = new QecPortalEntities();
//        // GET: ECourseFolder
//        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult ECourseFolderMain()
//        {

//            //dropdown

//            var lstTerm = (from d in db.Terms
//                           select d).ToList();

//            ViewBag.Terms = new SelectList(lstTerm.ToList(), "TermID", "Semester");

//            var lstdep = (from d in db.Departments
//                          select d).ToList();

//            ViewBag.dep = new SelectList(lstdep.ToList(), "DepartmentID", "DepartmentName");

//            var lstprog = (from d in db.Programs
//                           select d).ToList();

//            ViewBag.prog = new SelectList(lstprog.ToList(), "ProgramID", "Description");

//            var lstcourse = (from d in db.Courses
//                             select d).ToList();

//            ViewBag.course = new SelectList(lstcourse.ToList(), "CourseID", "CourseTitle");

//            var lstins = (from d in db.Instructors
//                           select d).ToList();

//            ViewBag.instructor = new SelectList(lstins.ToList(), "InstructorID", "InstructorName");

//            var ECourse = new SelectList(db.ECourseFoders.ToList(), "ECourse", "ECourse");
//            ViewData["ECourse"] = ECourse;
//            var ECourseModel = from d in db.ECourseFoders
//                               join t in db.Terms on d.TermID equals t.TermID
//                               join p in db.Programs on d.ProgramID equals p.ProgramID
//                               join c in db.Courses on d.CourseID equals c.CourseID
//                               join i in db.Instructors on d.InstructorID equals i.InstructorID
//                               join s in db.Status on d.StatusID equals s.StatusID
//                               select new ECourseModel { Courses = c, Terms = t, Programs = p, Instructors = i, Statuses= s };

//            return View(ECourseModel);
//            //return View();
//        }
//    }
//}