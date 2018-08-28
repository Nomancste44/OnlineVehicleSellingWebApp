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
    public class ColorOfVehicleController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();

        // GET: /ColorOfVehicle/
        public ActionResult Index()
        {
            return View(db.ColorOfVehilces.ToList());
        }

        // GET: /ColorOfVehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorOfVehilce colorofvehilce = db.ColorOfVehilces.Find(id);
            if (colorofvehilce == null)
            {
                return HttpNotFound();
            }
            return View(colorofvehilce);
        }

        // GET: /ColorOfVehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ColorOfVehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ColorOfVehicleId,ColorOfVehicleName")] ColorOfVehilce colorofvehilce)
        {
            if (ModelState.IsValid)
            {
                db.ColorOfVehilces.Add(colorofvehilce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colorofvehilce);
        }

        // GET: /ColorOfVehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorOfVehilce colorofvehilce = db.ColorOfVehilces.Find(id);
            if (colorofvehilce == null)
            {
                return HttpNotFound();
            }
            return View(colorofvehilce);
        }

        // POST: /ColorOfVehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ColorOfVehicleId,ColorOfVehicleName")] ColorOfVehilce colorofvehilce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colorofvehilce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colorofvehilce);
        }

        // GET: /ColorOfVehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorOfVehilce colorofvehilce = db.ColorOfVehilces.Find(id);
            if (colorofvehilce == null)
            {
                return HttpNotFound();
            }
            return View(colorofvehilce);
        }

        // POST: /ColorOfVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ColorOfVehilce colorofvehilce = db.ColorOfVehilces.Find(id);
            db.ColorOfVehilces.Remove(colorofvehilce);
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
