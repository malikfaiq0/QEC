using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQecPortal.Models;
using System.IO;
using System.Data;

namespace WebQecPortal.Controllers
{
    public class ECourseFolderController : Controller
    {
        QecPortalEntities db = new QecPortalEntities();
        // GET: ECourseFolder
        public ActionResult Index()
        {
            List<ObjFile> ObjFiles = new List<ObjFile>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/App_Data/File/")))
            {
                FileInfo fi = new FileInfo(strfile);
                ObjFile obj = new ObjFile();
                obj.File = fi.Name;
                obj.Size = fi.Length;
                obj.Type = GetFileTypeByExtension(fi.Extension);
                ObjFiles.Add(obj);
            }

            return View(ObjFiles);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/App_Data/File/"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);





            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        private string GetFileTypeByExtension(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".docx":
                case ".doc":
                    return "Microsoft Word Document";
                case ".xlsx":
                case ".xls":
                    return "Microsoft Excel Document";
                case ".txt":
                    return "Text Document";
                case ".jpg":
                case ".png":
                    return "Image";
                default:
                    return "Unknown";
            }
        }
        [HttpPost]
        public ActionResult Index(ObjFile doc)
        {
            foreach (var file in doc.files)
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/App_Data/File/"), fileName);
                    file.SaveAs(filePath);
                }
            }
            TempData["Message"] = "files uploaded successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase postedFile)
        {
            string filePath = "";
            filePath = Server.MapPath("~/App_Data/File/");
            if (postedFile == null)
            {
                postedFile = Request.Files["userFile"];            
            }
            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = filePath + Path.GetFileName(postedFile.FileName);
            postedFile.SaveAs(filePath);
            ViewBag.Massage = "File Saved";
            return View();

        }

        public ActionResult ECourseFolderMain()
        {

            //dropdown

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

            var lstins = (from d in db.Instructors
                          select d).ToList();

            ViewBag.instructor = new SelectList(lstins.ToList(), "InstructorID", "InstructorName");

            var ECourse = new SelectList(db.ECourseFoders.ToList(), "ECourse", "ECourse");
            ViewData["ECourse"] = ECourse;
            var ECourseModel = from d in db.ECourseFoders
                               join t in db.Terms on d.TermID equals t.TermID
                               join p in db.Programs on d.ProgramID equals p.ProgramID
                               join c in db.Courses on d.CourseID equals c.CourseID
                               join i in db.Instructors on d.InstructorID equals i.InstructorID
                               join s in db.Status on d.StatusID equals s.StatusID
                               select new ECourseModel { Courses = c, Terms = t, Programs = p, Instructors = i, Statuses = s };

            return View(ECourseModel);
            //return View();
        }
    }
}

public class ObjFile
{
    public IEnumerable<HttpPostedFileBase> files { get; set; }
    public string File { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}
