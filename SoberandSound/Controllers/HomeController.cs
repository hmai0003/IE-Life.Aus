using SoberandSound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace SoberandSound.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext(WebConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString);
        //private MyDbContext db = new MyDbContext("LifeAusDatabase");

        public ActionResult Index()
        {


            return View();
        }


        public ActionResult Quiz()
        {
            return View();
        }

        public ActionResult Validate()
        {
            return View();
        }

        public ActionResult Game()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            if (db.Life.Count() == 0)
            {
                string[] ausW, engW;
                ausW = new string[12] { "Straya", "Brekkie", "Arvo", "Evo", "Defo", "Devo", "Vego", "Mozzie", "Dunny", "Servo", "Ta", "Barbie" };
                engW = new string[12] { "Australia", "Breakfast", "Afternoon", "Evening", "Definitely", "Devastated", "Vegetarian", "Mosquito", "Toilet", "Service Station", "Thank you", "Barbeque" };
                for (int i = 0; i < ausW.Count(); i++)
                {
                    Lifestyle ls = new Lifestyle();
                    ls.ausWord = ausW[i];
                    ls.engWord = engW[i];
                    db.Life.Add(ls);
                    db.SaveChanges();
                }
            }
            return View();
        }

    }
}

