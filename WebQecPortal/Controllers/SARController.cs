using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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


   
            var SARList  = from d in db.StudentSARs
                         
                               join td in db.Courses on d.CourseID equals td.CourseID
                               
                               join ps in db.Students on d.StudentID equals ps.StudentID
                             
                             
                    
                               select new SARList { Students = ps };
            var studentSARs = db.StudentSARs.Include(s => s.Course).Include(s => s.Student);
            return View(db.StudentSARs.ToList());

        }

            public ActionResult StudentEvaluationDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSAR studentSAR = db.StudentSARs.Find(id);
            if (studentSAR == null)
            {
                return HttpNotFound();
            }
            return View(studentSAR);
        }
    }
}