using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NinjaDomain.Clases;
using NinjaDomain.DataModels;

namespace MVC5.Controllers
{
    public class NinjasController : Controller
    {
        private NinjaContext db = new NinjaContext();

        // GET: Ninjas
        public ActionResult Index()
        {
            var ninjas = db.Ninjas.Include(n => n.Clan);
            return View(ninjas.ToList());
        }

        // GET: Ninjas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ninja ninja = db.Ninjas.Find(id);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            return View(ninja);
        }

        // GET: Ninjas/Create
        public ActionResult Create()
        {
            ViewBag.ClanID = new SelectList(db.Clans, "Id", "ClanName");
            return View();
        }

        // POST: Ninjas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ServedInOniwaban,ClanID,DateOfBirth,DateModified,DateCreated")] Ninja ninja)
        {
            if (ModelState.IsValid)
            {
                db.Ninjas.Add(ninja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClanID = new SelectList(db.Clans, "Id", "ClanName", ninja.ClanID);
            return View(ninja);
        }

        // GET: Ninjas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ninja ninja = db.Ninjas.Find(id);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClanID = new SelectList(db.Clans, "Id", "ClanName", ninja.ClanID);
            return View(ninja);
        }

        // POST: Ninjas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ServedInOniwaban,ClanID,DateOfBirth,DateModified,DateCreated")] Ninja ninja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ninja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClanID = new SelectList(db.Clans, "Id", "ClanName", ninja.ClanID);
            return View(ninja);
        }

        // GET: Ninjas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ninja ninja = db.Ninjas.Find(id);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            return View(ninja);
        }

        // POST: Ninjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ninja ninja = db.Ninjas.Find(id);
            db.Ninjas.Remove(ninja);
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
