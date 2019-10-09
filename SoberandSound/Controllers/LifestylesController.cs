using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using SoberandSound.Models;

namespace SoberandSound.Controllers
{
    public class LifestylesController : Controller
    {
        private MyDbContext db = new MyDbContext(WebConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString);
        //private MyDbContext db = new MyDbContext("LifeAusDatabase");

        // GET: Lifestyles
        public ActionResult Index()
        {
            return View(db.Life.ToList());
        }

        // GET: Lifestyles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lifestyle lifestyle = db.Life.Find(id);
            if (lifestyle == null)
            {
                return HttpNotFound();
            }
            return View(lifestyle);
        }

        // GET: Lifestyles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lifestyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ausWord,engWord")] Lifestyle lifestyle)
        {
            if (ModelState.IsValid)
            {
                db.Life.Add(lifestyle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lifestyle);
        }

        // GET: Lifestyles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lifestyle lifestyle = db.Life.Find(id);
            if (lifestyle == null)
            {
                return HttpNotFound();
            }
            return View(lifestyle);
        }

        // POST: Lifestyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ausWord,engWord")] Lifestyle lifestyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lifestyle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lifestyle);
        }

        // GET: Lifestyles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lifestyle lifestyle = db.Life.Find(id);
            if (lifestyle == null)
            {
                return HttpNotFound();
            }
            return View(lifestyle);
        }

        // POST: Lifestyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lifestyle lifestyle = db.Life.Find(id);
            db.Life.Remove(lifestyle);
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
