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
    public class SteerTypeController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();

        // GET: /SteerType/
        public ActionResult Index()
        {
            return View(db.SteerTypes.ToList());
        }

        // GET: /SteerType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SteerType steertype = db.SteerTypes.Find(id);
            if (steertype == null)
            {
                return HttpNotFound();
            }
            return View(steertype);
        }

        // GET: /SteerType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SteerType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SteerTypeId,SteerTypeName")] SteerType steertype)
        {
            if (ModelState.IsValid)
            {
                db.SteerTypes.Add(steertype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(steertype);
        }

        // GET: /SteerType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SteerType steertype = db.SteerTypes.Find(id);
            if (steertype == null)
            {
                return HttpNotFound();
            }
            return View(steertype);
        }

        // POST: /SteerType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SteerTypeId,SteerTypeName")] SteerType steertype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(steertype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(steertype);
        }

        // GET: /SteerType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SteerType steertype = db.SteerTypes.Find(id);
            if (steertype == null)
            {
                return HttpNotFound();
            }
            return View(steertype);
        }

        // POST: /SteerType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SteerType steertype = db.SteerTypes.Find(id);
            db.SteerTypes.Remove(steertype);
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
