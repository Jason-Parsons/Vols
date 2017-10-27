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
    public class userJobsController : Controller
    {
        private VolsDBEntities db = new VolsDBEntities();

        // GET: userJobs
        public ActionResult Index()
        {
            var userJob = db.userJob.Include(u => u.job).Include(u => u.user);
            return View(userJob.ToList());
        }

        // GET: userJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userJob userJob = db.userJob.Find(id);
            if (userJob == null)
            {
                return HttpNotFound();
            }
            return View(userJob);
        }

        // GET: userJobs/Create
        public ActionResult Create()
        {
            ViewBag.jobID = new SelectList(db.job, "jobID", "description");
            ViewBag.userID = new SelectList(db.user, "userID", "firstName");
            return View();
        }

        // POST: userJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userJobID,userID,jobID")] userJob userJob)
        {
            if (ModelState.IsValid)
            {
                db.userJob.Add(userJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jobID = new SelectList(db.job, "jobID", "description", userJob.jobID);
            ViewBag.userID = new SelectList(db.user, "userID", "firstName", userJob.userID);
            return View(userJob);
        }

        // GET: userJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userJob userJob = db.userJob.Find(id);
            if (userJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.jobID = new SelectList(db.job, "jobID", "description", userJob.jobID);
            ViewBag.userID = new SelectList(db.user, "userID", "firstName", userJob.userID);
            return View(userJob);
        }

        // POST: userJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userJobID,userID,jobID")] userJob userJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobID = new SelectList(db.job, "jobID", "description", userJob.jobID);
            ViewBag.userID = new SelectList(db.user, "userID", "firstName", userJob.userID);
            return View(userJob);
        }

        // GET: userJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userJob userJob = db.userJob.Find(id);
            if (userJob == null)
            {
                return HttpNotFound();
            }
            return View(userJob);
        }

        // POST: userJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userJob userJob = db.userJob.Find(id);
            db.userJob.Remove(userJob);
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
