using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EliteInternationDemoWebAPP.Models;
using EliteInternationDemoWebAPP.Context;

namespace EliteInternationDemoWebAPP.Controllers
{
    public class VehicleController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();

        // GET: /Vehicle/
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.ColorOfVehilce).Include(v => v.FuelType).Include(v => v.GearType).Include(v => v.SteerType).Include(v => v.TypeOfVehicle);
            foreach (var aVehicle in vehicles)
            {
                var firstOrDefault = db.VehicleImages.FirstOrDefault(x => x.VehicleId == aVehicle.VehicleId);
                if (firstOrDefault != null)
                {
                    var aVehicleImage=  firstOrDefault.VehicleImages;
                    string name = aVehicle.VehicleId.ToString();
                    ViewData[name] = "data:Image/png;base64," +
                                                              Convert.ToBase64String(aVehicleImage);
                }
            }
            return View(vehicles.ToList());
        }

        // GET: /Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: /Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.ColorOfVehicleId = new SelectList(db.ColorOfVehilces, "ColorOfVehicleId", "ColorOfVehicleName");
            ViewBag.FuelTypeId = new SelectList(db.FuelTypes, "FuelTypeId", "FuelTypeName");
            ViewBag.GearTypeId = new SelectList(db.GearTypes, "GearTypeId", "GearTypeName");
            ViewBag.SteerTypeId = new SelectList(db.SteerTypes, "SteerTypeId", "SteerTypeName");
            ViewBag.VehicleTypeId = new SelectList(db.TypesOfVehicles, "VehicleTypeId", "VehicleTypeName");
            return View();
        }

        // POST: /Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VehicleId,Model,Registraion,EngineCapacity," +
        "Price,SteerTypeId,MileAges,GearTypeId,FuelTypeId,ColorOfVehicleId,VehicleTypeId")]
         Vehicle vehicle, IEnumerable<HttpPostedFileBase> httpPostedFileBases)
        {
            IEnumerable<HttpPostedFileBase> httpPostedFile = httpPostedFileBases;
           
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                if (httpPostedFile != null)
                {
                    foreach (var afile in httpPostedFile)
                    {
                        VehicleImage aVehicleImage = new VehicleImage();
                        Stream stream = afile.InputStream;
                        BinaryReader brd = new BinaryReader(stream);
                        byte[] bytes = brd.ReadBytes((int) stream.Length);
                        aVehicleImage.VehicleId = vehicle.VehicleId;
                        aVehicleImage.VehicleImages = bytes;
                        db.VehicleImages.Add(aVehicleImage);
                        db.SaveChanges();

                    }
                }
                return RedirectToAction("Index");
            }

            ViewBag.ColorOfVehicleId = new SelectList(db.ColorOfVehilces, "ColorOfVehicleId", "ColorOfVehicleName", vehicle.ColorOfVehicleId);
            ViewBag.FuelTypeId = new SelectList(db.FuelTypes, "FuelTypeId", "FuelTypeName", vehicle.FuelTypeId);
            ViewBag.GearTypeId = new SelectList(db.GearTypes, "GearTypeId", "GearTypeName", vehicle.GearTypeId);
            ViewBag.SteerTypeId = new SelectList(db.SteerTypes, "SteerTypeId", "SteerTypeName", vehicle.SteerTypeId);
            ViewBag.VehicleTypeId = new SelectList(db.TypesOfVehicles, "VehicleTypeId", "VehicleTypeName", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: /Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorOfVehicleId = new SelectList(db.ColorOfVehilces, "ColorOfVehicleId", "ColorOfVehicleName", vehicle.ColorOfVehicleId);
            ViewBag.FuelTypeId = new SelectList(db.FuelTypes, "FuelTypeId", "FuelTypeName", vehicle.FuelTypeId);
            ViewBag.GearTypeId = new SelectList(db.GearTypes, "GearTypeId", "GearTypeName", vehicle.GearTypeId);
            ViewBag.SteerTypeId = new SelectList(db.SteerTypes, "SteerTypeId", "SteerTypeName", vehicle.SteerTypeId);
            ViewBag.VehicleTypeId = new SelectList(db.TypesOfVehicles, "VehicleTypeId", "VehicleTypeName", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: /Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="VehicleId,Model,Registraion,EngineCapacity,Price,SteerTypeId,MileAges,GearTypeId,FuelTypeId,ColorOfVehicleId,VehicleTypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorOfVehicleId = new SelectList(db.ColorOfVehilces, "ColorOfVehicleId", "ColorOfVehicleName", vehicle.ColorOfVehicleId);
            ViewBag.FuelTypeId = new SelectList(db.FuelTypes, "FuelTypeId", "FuelTypeName", vehicle.FuelTypeId);
            ViewBag.GearTypeId = new SelectList(db.GearTypes, "GearTypeId", "GearTypeName", vehicle.GearTypeId);
            ViewBag.SteerTypeId = new SelectList(db.SteerTypes, "SteerTypeId", "SteerTypeName", vehicle.SteerTypeId);
            ViewBag.VehicleTypeId = new SelectList(db.TypesOfVehicles, "VehicleTypeId", "VehicleTypeName", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: /Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: /Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            IEnumerable<VehicleImage> vehicleImages = db.VehicleImages.Where(x => x.VehicleId == id);
            db.VehicleImages.RemoveRange(vehicleImages);
            db.SaveChanges();
            if (vehicle != null) db.Vehicles.Remove(vehicle);
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
