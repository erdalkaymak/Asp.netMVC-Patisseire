using DataAccessLayer;
using DataAccessLayer.MyEntities;
using MVCmyPatisserie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCmyPatisserie.Controllers
{
    public class PatisserieController : Controller
    {
        // GET: Patisserie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cakes()
        {
            List<Cake> cakeList = new List<Cake>();
            Model1 ctx = new Model1();
            cakeList = ctx.Cakes.ToList();
                
            return View(cakeList);
        }

        public ActionResult Drinks()
        {
            List<Drink> drinkList = new List<Drink>();
            Model1 ctx = new Model1();
            drinkList = ctx.Drinks.ToList();

            return View(drinkList);
        }

        public ActionResult AddCakes()
        {
            if (Session["username"] == null)
            return RedirectToAction("UserLogin", "Home");
            return View();
        }
        

        [HttpPost]
        public ActionResult AddCakes(CakeModelView model)
        {
            if (!ModelState.IsValid)
                //server validationlar modelin içinde
                return View(model);

            Model1 ctx = new Model1();
            Cake c1 = new Cake();
            c1.Id = model.Id;
            c1.Description = model.Description;
            c1.Name = model.Name;
            c1.Price = model.Price;
            
            ctx.Cakes.Add(c1);
            ctx.SaveChanges();

            string filename = model.Name + "_" + model.Id+".jpg";
            string filePath = Server.MapPath("/Images/") + filename;
            Request.Files["myimage"].SaveAs(filePath);
            model.ImgeUrl = filename;
            c1.ImgeUrl = model.ImgeUrl;
            ctx.SaveChanges();
            return View();
        }

        
        public ActionResult AddDrinks()
        {
            if (Session["username"] == null)
            return RedirectToAction("UserLogin", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult AddDrinks(Drink model)
        {
            Model1 ctx = new Model1();
            ctx.Drinks.Add(model);
            ctx.SaveChanges();

            string filename=model.Name+"_"+model.Id + ".jpg";
            string filepath = Server.MapPath("/Images/") + filename;
            Request.Files["MyDrinkImageFile"].SaveAs(filepath);
            model.ImageUrl = filename;
            ctx.SaveChanges();
            return View();
        }

    }
}