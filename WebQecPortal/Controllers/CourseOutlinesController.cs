using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic; 
using System.Net;
using System.Web;
using System.Windows;
using System.Web.Mvc;
using WebQecPortal.Models;

namespace WebQecPortal.Controllers
{
    public class CourseOutlinesController : Controller
    {
        private QecPortalEntities db = new QecPortalEntities();
        
        // GET: CourseOutlines
        public ActionResult Index()
        {
            
            var courseOutlines = db.CourseOutlines.Include(c => c.Course).Include(c => c.Department).Include(c => c.Instructor).Include(c => c.Program).Include(c => c.Status).Include(c => c.Term);
            return View(courseOutlines.ToList());
            // return View(db.CourseOutlines.Where(x => x.Course.Contains()).ToList());
           // return View(db.CourseOutlines.Take(10));

          




        }

        [HttpPost]
        public JsonResult SearchCourseOutline(string Semester)
        {
            var courseOutlines = db.CourseOutlines.Include(c => c.Course).Include(c => c.Department).Include(c => c.Instructor).Include(c => c.Program).Include(c => c.Status).Include(c => c.Term);

            var lstTerm = from d in db.Terms
                          where d.Semester.Contains(Semester)
                          select d;
            return Json(db.CourseOutlines.ToList().Take(10));
        }



        // GET: CourseOutlines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseOutline courseOutline = db.CourseOutlines.Find(id);
            if (courseOutline == null)
            {
                return HttpNotFound();
            }
            return View(courseOutline);
        }

        // GET: CourseOutlines/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseTitle");
            ViewBag.CourseID2 = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorName");
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "Description");
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusID");
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Semester");
            return View();
        }

        // POST: CourseOutlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseOutlineID,CourseID,ProgramID,InstructorID,StatusID,TermID,DepartmentID")] CourseOutline courseOutline)
        {
            if (ModelState.IsValid)
            {
                db.CourseOutlines.Add(courseOutline);
                db.SaveChanges();
                return RedirectToAction("Index","CourseOutlines");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", "CourseTitle", courseOutline.CourseID);
            ViewBag.CourseOutlineID = new SelectList(db.CourseOutlines, "CourseOutlineID", "CourseOutlineID", courseOutline.CourseOutlineID);
            ViewBag.CourseOutlineID = new SelectList(db.CourseOutlines, "CourseOutlineID", "CourseOutlineID", courseOutline.CourseOutlineID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", courseOutline.DepartmentID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorName", courseOutline.InstructorID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "Description", courseOutline.ProgramID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusID", courseOutline.StatusID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Semester", courseOutline.TermID);
            return View(courseOutline);
        }

        // GET: CourseOutlines/Edit/5
        public ActionResult Edit(int? id)
        {
         

            CourseOutline courseOutline = new CourseOutline();
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", "CourseTitle", courseOutline.CourseID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", courseOutline.DepartmentID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorName", courseOutline.InstructorID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "Description", courseOutline.ProgramID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusID", courseOutline.StatusID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Semester", courseOutline.TermID);
            return View(db.CourseOutlines.Where(x => x.CourseOutlineID == id).FirstOrDefault());

        }


        // POST: CourseOutlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseOutlineID,CourseID,ProgramID,InstructorID,StatusID,TermID,DepartmentID")] CourseOutline courseOutline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseOutline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CourseOutlineMain","CourseOutline");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", "CourseTitle", courseOutline.CourseID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", courseOutline.DepartmentID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorName", courseOutline.InstructorID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "Description", courseOutline.ProgramID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusID", courseOutline.StatusID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Semester", courseOutline.TermID);
            return View(courseOutline);
        }

        // GET: CourseOutlines/Delete/5
        public ActionResult Delete(int id)
        {          
            CourseOutline courseOutline = db.CourseOutlines.Find(id);
            return View(courseOutline);
        }

        // POST: CourseOutlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseOutline courseOutline = db.CourseOutlines.Find(id);
            db.CourseOutlines.Remove(courseOutline);
            db.SaveChanges();
            return RedirectToAction("Index", "CourseOutlines");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
