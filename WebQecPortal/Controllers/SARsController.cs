using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQecPortal.Models;
using System.IO;

namespace WebQecPortal.Controllers
{
    public class SARsController : Controller
    {
        private QecPortalEntities db = new QecPortalEntities();

        // GET: SARs
        public ActionResult Index()
        {
            var sARs = db.SARs.Include(s => s.Course).Include(s => s.Department).Include(s => s.Program).Include(s => s.Term);
            return View(sARs.ToList());
        }

        
       

        // GET: SARs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAR sAR = db.SARs.Find(id);
            if (sAR == null)
            {
                return HttpNotFound();
            }
            return View(sAR);
        }

        // GET: SARs/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "Description");
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Semester");
            return View();
        }


        //[HttpPost]
        //public ActionResult Create(SAR sAR)
        //{
        //    string path = Server.MapPath("~/App_Data/File");
        //    string filename = Path.GetFileName(sAR.File.FileName);

        //    string fullpath = Path.Combine(path, filename);

        //    sAR.File.SaveAs(fullpath);

        //    ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
        //    ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
        //    ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "Description");
        //    ViewBag.TermID = new SelectList(db.Terms, "TermID", "Semester");
        //    return View();
        //}

        // POST: SARs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SARID,DepartmentID,ProgramID,TermID,CourseID")] SAR sAR, HttpPostedFileBase file)
        {
            
            if (ModelState.IsValid)
            {
                db.SARs.Add(sAR);

                db.SaveChanges();
                //string path = Server.MapPath("~/App_Data/File");
                //string filename = Path.GetFileName(file.FileName);

                //string fullpath = Path.Combine(path, filename);
                //file.SaveAs(fullpath);
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", sAR.CourseID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", sAR.DepartmentID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "Description", sAR.ProgramID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Semester", sAR.TermID);


            return View(sAR);
        }

        // GET: SARs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAR sAR = db.SARs.Find(id);
            if (sAR == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", sAR.CourseID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", sAR.DepartmentID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "Description", sAR.ProgramID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Semester", sAR.TermID);
            return View(sAR);
        }

        // POST: SARs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SARID,DepartmentID,ProgramID,TermID,CourseID")] SAR sAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", sAR.CourseID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", sAR.DepartmentID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "Description", sAR.ProgramID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Semester", sAR.TermID);
            return View(sAR);
        }

        // GET: SARs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAR sAR = db.SARs.Find(id);
            if (sAR == null)
            {
                return HttpNotFound();
            }
            return View(sAR);
        }

        // POST: SARs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SAR sAR = db.SARs.Find(id);
            db.SARs.Remove(sAR);
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
