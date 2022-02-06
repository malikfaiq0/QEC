using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQecPortal.Models;

namespace WebQecPortal.Controllers
{
    public class LoginController : Controller
    {
        private QecPortalEntities db = new QecPortalEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login objcheck)
        {
            var user = db.Logins.Where(model => model.username == objcheck.username && model.password == objcheck.password).FirstOrDefault();
            if (user != null)
            {
                Session["UserId"] = objcheck.id.ToString();
                Session["UserName"] = objcheck.username.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull !!')</script>";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or password is incorrect!!')</script>";
                return View();


            }
        }

        public ActionResult Logout()
        {

            Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}