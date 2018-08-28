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
    public class FuelTypeController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();

        // GET: /FuelType/
        public ActionResult Index()
        {
            return View(db.FuelTypes.ToList());
        }

        // GET: /FuelType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelType fueltype = db.FuelTypes.Find(id);
            if (fueltype == null)
            {
                return HttpNotFound();
            }
            return View(fueltype);
        }

        // GET: /FuelType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FuelType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FuelTypeId,FuelTypeName")] FuelType fueltype)
        {
            if (ModelState.IsValid)
            {
                db.FuelTypes.Add(fueltype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fueltype);
        }

        // GET: /FuelType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelType fueltype = db.FuelTypes.Find(id);
            if (fueltype == null)
            {
                return HttpNotFound();
            }
            return View(fueltype);
        }

        // POST: /FuelType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FuelTypeId,FuelTypeName")] FuelType fueltype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fueltype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fueltype);
        }

        // GET: /FuelType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelType fueltype = db.FuelTypes.Find(id);
            if (fueltype == null)
            {
                return HttpNotFound();
            }
            return View(fueltype);
        }

        // POST: /FuelType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FuelType fueltype = db.FuelTypes.Find(id);
            db.FuelTypes.Remove(fueltype);
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
