using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vols.Models;

namespace Vols.Controllers
{
    public class userAccessesController : Controller
    {
        private VolsDBEntities db = new VolsDBEntities();

        // GET: userAccesses
        public ActionResult Index()
        {
            return View(db.userAccess.ToList());
        }

        // GET: userAccesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userAccess userAccess = db.userAccess.Find(id);
            if (userAccess == null)
            {
                return HttpNotFound();
            }
            return View(userAccess);
        }

        // GET: userAccesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userAccesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userAccess1")] userAccess userAccess)
        {
            if (ModelState.IsValid)
            {
                db.userAccess.Add(userAccess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccess);
        }

        // GET: userAccesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userAccess userAccess = db.userAccess.Find(id);
            if (userAccess == null)
            {
                return HttpNotFound();
            }
            return View(userAccess);
        }

        // POST: userAccesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userAccess1")] userAccess userAccess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccess);
        }

        // GET: userAccesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userAccess userAccess = db.userAccess.Find(id);
            if (userAccess == null)
            {
                return HttpNotFound();
            }
            return View(userAccess);
        }

        // POST: userAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userAccess userAccess = db.userAccess.Find(id);
            db.userAccess.Remove(userAccess);
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
