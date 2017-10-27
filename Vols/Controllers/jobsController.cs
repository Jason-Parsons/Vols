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
    public class jobsController : Controller
    {
        private VolsDBEntities db = new VolsDBEntities();

        // GET: jobs
        public ActionResult Index()
        {
            var job = db.job.Include(j => j.user).Include(j => j.jobPics);
            return View(job.ToList());
        }

        // GET: jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = db.job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: jobs/Create
        public ActionResult Create()
        {
            ViewBag.createdBy = new SelectList(db.user, "userID", "firstName");
            ViewBag.jobID = new SelectList(db.jobPics, "jobID", "before");
            return View();
        }

        // POST: jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jobID,locationLat,locationLong,date,time,description,numVolsNeed,createdBy")] job job)
        {
            if (ModelState.IsValid)
            {
                db.job.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.createdBy = new SelectList(db.user, "userID", "firstName", job.createdBy);
            ViewBag.jobID = new SelectList(db.jobPics, "jobID", "before", job.jobID);
            return View(job);
        }

        // GET: jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = db.job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.createdBy = new SelectList(db.user, "userID", "firstName", job.createdBy);
            ViewBag.jobID = new SelectList(db.jobPics, "jobID", "before", job.jobID);
            return View(job);
        }

        // POST: jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobID,locationLat,locationLong,date,time,description,numVolsNeed,createdBy")] job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.createdBy = new SelectList(db.user, "userID", "firstName", job.createdBy);
            ViewBag.jobID = new SelectList(db.jobPics, "jobID", "before", job.jobID);
            return View(job);
        }

        // GET: jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = db.job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            job job = db.job.Find(id);
            db.job.Remove(job);
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
