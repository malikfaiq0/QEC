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
    public class StudentSARsController : Controller
    {
        private QecPortalEntities db = new QecPortalEntities();

        // GET: StudentSARs
        public ActionResult Index()
        {
            var studentSARs = db.StudentSARs.Include(s => s.Course).Include(s => s.Student);
            return View(studentSARs.ToList());
        }

        // GET: StudentSARs/Details/5
        public ActionResult Details(int? id)
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

        // GET: StudentSARs/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentRegNum");
            return View();
        }

        // POST: StudentSARs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentSARID,CourseID,StudentID,AssignmentNumber,QuizNumber,Project,AssignMarks,QuizMarks,ProjectMarks")] StudentSAR studentSAR)
        {
            if (ModelState.IsValid)
            {
                db.StudentSARs.Add(studentSAR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", studentSAR.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentRegNum", studentSAR.StudentID);
            return View(studentSAR);
        }

        // GET: StudentSARs/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", studentSAR.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentRegNum", studentSAR.StudentID);
            return View(studentSAR);
        }

        // POST: StudentSARs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentSARID,CourseID,StudentID,AssignmentNumber,QuizNumber,Project,AssignMarks,QuizMarks,ProjectMarks")] StudentSAR studentSAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentSAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", studentSAR.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentRegNum", studentSAR.StudentID);
            return View(studentSAR);
        }

        // GET: StudentSARs/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: StudentSARs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentSAR studentSAR = db.StudentSARs.Find(id);
            db.StudentSARs.Remove(studentSAR);
            db.SaveChanges();
            return RedirectToAction("Index");
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
