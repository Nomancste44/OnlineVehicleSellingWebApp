using System;
using System.Collections;
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
    public class VehicleImageController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();

        // GET: /VehicleImage/
        public ActionResult Index()
        {
            var vehicleimages = db.VehicleImages.Include(v => v.Vehicle);
            return View(vehicleimages.ToList());
        }

        // GET: /VehicleImage/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<VehicleImage> vehicleImages = db.VehicleImages.Where(x => x.VehicleId == id);
            ViewBag.vehicleImages = vehicleImages;
            Vehicle aVehicle = db.Vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (aVehicle == null)
            {
                return HttpNotFound();
            }
            return View(aVehicle);
        }

        // GET: /VehicleImage/Create
        public ActionResult Create()
        {
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Model");
            return View();
        }

        // POST: /VehicleImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VehicleImageId,VehicleImages,VehicleId")] VehicleImage vehicleimage)
        {
            if (ModelState.IsValid)
            {
                db.VehicleImages.Add(vehicleimage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Model", vehicleimage.VehicleId);
            return View(vehicleimage);
        }

        // GET: /VehicleImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleImage vehicleimage = db.VehicleImages.Find(id);
            if (vehicleimage == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Model", vehicleimage.VehicleId);
            return View(vehicleimage);
        }

        // POST: /VehicleImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="VehicleImageId,VehicleImages,VehicleId")] VehicleImage vehicleimage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleimage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Model", vehicleimage.VehicleId);
            return View(vehicleimage);
        }

        // GET: /VehicleImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleImage vehicleimage = db.VehicleImages.Find(id);
            if (vehicleimage == null)
            {
                return HttpNotFound();
            }
            return View(vehicleimage);
        }

        // POST: /VehicleImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleImage vehicleimage = db.VehicleImages.Find(id);
            db.VehicleImages.Remove(vehicleimage);
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
