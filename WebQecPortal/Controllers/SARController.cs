using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQecPortal.Models;


namespace WebQecPortal.Controllers
{
    public class SARController : Controller
    {
        QecPortalEntities db = new QecPortalEntities();
       

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SARmanager()

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

            var Sar = new SelectList(db.SARs.ToList(), "Sar", "Sar");
            ViewData["Sar"] = Sar;

            var SARViewModel = from d in db.SARs
                               join t in db.Terms on d.TermID equals t.TermID
                               join p in db.Programs on d.ProgramID equals p.ProgramID
                               join c in db.Courses on d.CourseID equals c.CourseID
                               select new SARDataModel { Courses = c, Terms = t, Programs = p };

            return View(SARViewModel);
        }
        public ActionResult StudentEvaluation()
        {
            return View();
        }
        public ActionResult StudentEvaluationDetails()
        {
            return View();
        }
    }
}