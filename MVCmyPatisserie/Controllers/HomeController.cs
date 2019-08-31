using DataAccessLayer;
using MVCmyPatisserie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCmyPatisserie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(AdminEntity model )
        {
            Model1 ctx = new Model1();

            var loggedUser = ctx.Users.Where(c => c.Username == model.Username && c.Password == model.Password).FirstOrDefault();

            if (loggedUser==null)
            {
                ViewBag.errorMessage = "username or passsword is wrong";
                ViewBag.data = "1";
                return View();
            }
            else
            {
                Session["username"] = model.Username;
                return RedirectToAction("Index", "Patisserie");
            }


            
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return View("UserLogin");
        }
    }
}