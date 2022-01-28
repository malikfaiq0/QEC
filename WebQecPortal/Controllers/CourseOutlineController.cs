using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQecPortal.Models;


namespace WebQecPortal.Controllers
{
    public class CourseOutlineController : Controller
    {
        QecPortalEntities db = new QecPortalEntities();

        // GET: CourseOutline
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CourseOutlineMain()
        {
            var lstTerm = (from d in db.Terms
                           select d).ToList();

            ViewBag.Terms = new SelectList(lstTerm.ToList(), "TermID", "Semester");

            var lstdep = (from d in db.Departments
                          select d).ToList();

            ViewBag.dep = new SelectList(lstdep.ToList(), "DepartmentID", "DepartmentName");

            var lstprog = (from d in db.Programs
                           select d).ToList();

            ViewBag.prog = new SelectList(lstprog.ToList(), "ProgramID", "Description");

            var Course = (from d in db.Courses
                           select d).ToList();

            ViewBag.course = new SelectList(Course.ToList(), "CourseID", "CourseTitle");

            var status = (from d in db.Status
                          select d).ToList();

            ViewBag.status = new SelectList(status.ToList(), "StatusID", "FolderStatus");

            var Sar = new SelectList(db.SARs.ToList(), "Sar", "Sar");
            ViewData["Sar"] = Sar;

            var CourseOutlineViewModel = from d in db.CourseOutlines
                               join t in db.Terms on d.TermID equals t.TermID
                               join p in db.Programs on d.ProgramID equals p.ProgramID
                               join c in db.Courses on d.CourseID equals c.CourseID
                               join a in db.Departments on d.DepartmentID equals a.DepartmentID
                               join s in db.Status on d.StatusID equals s.StatusID
             
                               select new ECourseModel { Courses = c, Terms = t, Programs = p, Departments =a, Statuses =s };

            return View(CourseOutlineViewModel);
        
        }

        //[HttpPost]
        //public ActionResult CourseOutlineMain(CourseOutline courseOutline)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CourseOutlines.Add(courseOutline);
        //          db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Term_id = new SelectList(db.Terms, "TermID", "Semester",);
        //    return View(courseOutline);
        //}

        [HttpPost]
        public JsonResult DeleteCourseOutline(int CourseOutlineID)
        {
            //Code
            bool result = false;
            CourseOutline c = db.CourseOutlines.Where(x => x.CourseOutlineID == CourseOutlineID).SingleOrDefault();
            if(c!=null)
            {
   
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

            
        }
            

     

        public ActionResult CourseOutlineForm()
        {
            return View();
        }
    }
}