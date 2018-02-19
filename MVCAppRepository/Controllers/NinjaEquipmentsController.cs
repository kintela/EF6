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

namespace MVCAppRepository.Controllers
{
    public class NinjaEquipmentsController : Controller
    {
        private NinjaContext db = new NinjaContext();

        // GET: NinjaEquipments
        public ActionResult Index()
        {
            return View(db.Equipment.ToList());
        }

        // GET: NinjaEquipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NinjaEquipment ninjaEquipment = db.Equipment.Find(id);
            if (ninjaEquipment == null)
            {
                return HttpNotFound();
            }
            return View(ninjaEquipment);
        }

        // GET: NinjaEquipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NinjaEquipments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,DateModified,DateCreated")] NinjaEquipment ninjaEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Equipment.Add(ninjaEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ninjaEquipment);
        }

        // GET: NinjaEquipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NinjaEquipment ninjaEquipment = db.Equipment.Find(id);
            if (ninjaEquipment == null)
            {
                return HttpNotFound();
            }
            return View(ninjaEquipment);
        }

        // POST: NinjaEquipments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,DateModified,DateCreated")] NinjaEquipment ninjaEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ninjaEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ninjaEquipment);
        }

        // GET: NinjaEquipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NinjaEquipment ninjaEquipment = db.Equipment.Find(id);
            if (ninjaEquipment == null)
            {
                return HttpNotFound();
            }
            return View(ninjaEquipment);
        }

        // POST: NinjaEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NinjaEquipment ninjaEquipment = db.Equipment.Find(id);
            db.Equipment.Remove(ninjaEquipment);
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
