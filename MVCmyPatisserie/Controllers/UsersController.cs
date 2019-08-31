using DataAccessLayer;
using DataAccessLayer.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCmyPatisserie.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            if (Session["username"] == null)
            return RedirectToAction("UserLogin", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string nameFilter,string emailFilter)
        {
            if (Session["username"] == null)
                return RedirectToAction("UserLogin", "Home");
            Model1 ctx = new Model1();
            List<User> userlist = ctx.Users.Where(c => c.Username.Contains(nameFilter) && c.Email.Contains(emailFilter)).ToList();
            return View(userlist);
        }

        
        public ActionResult UsersTablePartial(string nameFilter, string emailFilter)
        {
            Model1 ctx = new Model1();
            if (nameFilter == null)
            {
                nameFilter = "";
            }
            if (emailFilter == null)
            {
                emailFilter = "";
            }

            List<User> userlist = ctx.Users.Where(c => c.Username.Contains(nameFilter) && c.Email.Contains(emailFilter)).ToList();
            if (nameFilter == "" && emailFilter == "")
            {
                userlist = ctx.Users.ToList();
            }
            return View(userlist);          
        }


        public ActionResult Update(int id)
        {
            if (Session["username"] == null)
            return RedirectToAction("UserLogin", "Home");
            Model1 ctx = new Model1();
            User user = ctx.Users.Where(c => c.Id == id).FirstOrDefault();

            return View(user);
        }

        public ActionResult AddUser()
        {
            if (Session["username"] == null)
             return RedirectToAction("UserLogin", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            if (Session["username"] == null)
            return RedirectToAction("UserLogin", "Home");
            Model1 ctx = new Model1();
            if (user.Id > 0)
            {
                var model = ctx.Users.Where(c => c.Id == user.Id).FirstOrDefault();

                ctx.Entry(model).CurrentValues.SetValues(user);
            }
            else
            {
                var list = ctx.Users.Where(c => c.Username == user.Username).ToList();
                if (list.Count > 0)
                {
                    ViewBag.useExist =1;
                    ViewData["id"] = user.Id;
                    return View("AddUser", user);
                }
                ctx.Set<User>().Add(user);
            }
            
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["username"] == null)
                return RedirectToAction("UserLogin", "Home");
            Model1 ctx = new Model1();
            var user = ctx.Set<User>().Where(c => c.Id == id).FirstOrDefault();
            ctx.Users.Remove(user);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}