using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EliteInternationDemoWebAPP.Models;
using EliteInternationDemoWebAPP.Context;

namespace EliteInternationDemoWebAPP.Controllers
{
    public class GearTypeController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();

        // GET: /GearType/
        public ActionResult Index()
        {
            return View(db.GearTypes.ToList());
        }

        // GET: /GearType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GearType geartype = db.GearTypes.Find(id);
            if (geartype == null)
            {
                return HttpNotFound();
            }
            return View(geartype);
        }

        // GET: /GearType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GearType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GearTypeId,GearTypeName")] GearType geartype)
        {
            if (ModelState.IsValid)
            {
                db.GearTypes.Add(geartype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(geartype);
        }

        // GET: /GearType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GearType geartype = db.GearTypes.Find(id);
            if (geartype == null)
            {
                return HttpNotFound();
            }
            return View(geartype);
        }

        // POST: /GearType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GearTypeId,GearTypeName")] GearType geartype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geartype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(geartype);
        }

        // GET: /GearType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GearType geartype = db.GearTypes.Find(id);
            if (geartype == null)
            {
                return HttpNotFound();
            }
            return View(geartype);
        }

        // POST: /GearType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GearType geartype = db.GearTypes.Find(id);
            db.GearTypes.Remove(geartype);
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
