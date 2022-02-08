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
    public class CourseEvaluationController : Controller

    {
        QecPortalEntities db = new QecPortalEntities();
        // GET: CourseEvaluation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CourseEvaluationMain()
        {

            //dropdowns
            var lstTerm = (from d in db.Terms
                           select d).ToList();

            ViewBag.Terms = new SelectList(lstTerm.ToList(), "TermID", "Semester");

            var lstdep = (from d in db.Departments
                          select d).ToList();

            ViewBag.dep = new SelectList(lstdep.ToList(), "DepartmentID", "DepartmentName");

            var lstprog = (from d in db.Programs
                           select d).ToList();

            ViewBag.prog = new SelectList(lstprog.ToList(), "ProgramID", "Description");

            var lstcourse = (from d in db.Courses
                           select d).ToList();

            ViewBag.course = new SelectList(lstcourse.ToList(), "CourseID", "CourseTitle");


            //var lstp = (from pd in db.CourseEvaluations
            //            join od in db.Programs on pd.ProgramID equals od.ProgramID
            //            join ld in db.Terms on pd.TermID equals ld.TermID
            //            join cd in db.Courses on pd.CourseID equals cd.CourseID

            //            where od.Description=="BSSE" || ld.Semester=="fa20" || cd.CourseTitle== "Software Achitectur"
            //            select new
            //            {
            //                od.Description,

            //            }).ToList(); 

            //ViewBag.prog = String.Join(",", lstp);

            return View();
        }
        public ActionResult CourseEvaluationProgress()
            
        {
        
            return View();
        }
        public ActionResult CourseEvaluationAssignment()
        {
            var studentSARs = db.StudentSARs.Include(s => s.Course).Include(s => s.Student);
            return View(db.StudentSARs.ToList());
        }
        public ActionResult CourseEvaluationQuiz()
        {
            var studentSARs = db.StudentSARs.Include(s => s.Course).Include(s => s.Student);
            return View(db.StudentSARs.ToList());
        }
        public ActionResult CourseEvaluationProject()
        {
            return View();
        }
    }
}