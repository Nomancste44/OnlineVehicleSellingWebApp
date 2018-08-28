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
    public class TypeOfVehicleController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();

        // GET: /TypeOfVehicle/
        public ActionResult Index()
        {
            return View(db.TypesOfVehicles.ToList());
        }

        // GET: /TypeOfVehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfVehicle typeofvehicle = db.TypesOfVehicles.Find(id);
            if (typeofvehicle == null)
            {
                return HttpNotFound();
            }
            return View(typeofvehicle);
        }

        // GET: /TypeOfVehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TypeOfVehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VehicleTypeId,VehicleTypeName")] TypeOfVehicle typeofvehicle)
        {
            if (ModelState.IsValid)
            {
                db.TypesOfVehicles.Add(typeofvehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeofvehicle);
        }

        // GET: /TypeOfVehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfVehicle typeofvehicle = db.TypesOfVehicles.Find(id);
            if (typeofvehicle == null)
            {
                return HttpNotFound();
            }
            return View(typeofvehicle);
        }

        // POST: /TypeOfVehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="VehicleTypeId,VehicleTypeName")] TypeOfVehicle typeofvehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeofvehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeofvehicle);
        }

        // GET: /TypeOfVehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfVehicle typeofvehicle = db.TypesOfVehicles.Find(id);
            if (typeofvehicle == null)
            {
                return HttpNotFound();
            }
            return View(typeofvehicle);
        }

        // POST: /TypeOfVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfVehicle typeofvehicle = db.TypesOfVehicles.Find(id);
            db.TypesOfVehicles.Remove(typeofvehicle);
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
