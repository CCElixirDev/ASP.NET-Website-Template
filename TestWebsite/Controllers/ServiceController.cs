using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestWebsite.Models;

namespace TestWebsite.Controllers
{
    public class ServiceController : Controller
    {
        private TestContext db = new TestContext();

        // GET: Service
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        // GET: Service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceModel serviceModel = db.Services.Find(id);
            if (serviceModel == null)
            {
                return HttpNotFound();
            }
            return View(serviceModel);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceID,ServiceName,ServicePrice")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(serviceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceModel);
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceModel serviceModel = db.Services.Find(id);
            if (serviceModel == null)
            {
                return HttpNotFound();
            }
            return View(serviceModel);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceID,ServiceName,ServicePrice")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceModel);
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceModel serviceModel = db.Services.Find(id);
            if (serviceModel == null)
            {
                return HttpNotFound();
            }
            return View(serviceModel);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceModel serviceModel = db.Services.Find(id);
            db.Services.Remove(serviceModel);
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
