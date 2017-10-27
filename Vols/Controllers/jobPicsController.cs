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
    public class jobPicsController : Controller
    {
        private VolsDBEntities db = new VolsDBEntities();

        // GET: jobPics
        public ActionResult Index()
        {
            var jobPics = db.jobPics.Include(j => j.job);
            return View(jobPics.ToList());
        }

        // GET: jobPics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobPics jobPics = db.jobPics.Find(id);
            if (jobPics == null)
            {
                return HttpNotFound();
            }
            return View(jobPics);
        }

        // GET: jobPics/Create
        public ActionResult Create()
        {
            ViewBag.jobID = new SelectList(db.job, "jobID", "description");
            return View();
        }

        // POST: jobPics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jobID,before,after")] jobPics jobPics)
        {
            if (ModelState.IsValid)
            {
                db.jobPics.Add(jobPics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jobID = new SelectList(db.job, "jobID", "description", jobPics.jobID);
            return View(jobPics);
        }

        // GET: jobPics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobPics jobPics = db.jobPics.Find(id);
            if (jobPics == null)
            {
                return HttpNotFound();
            }
            ViewBag.jobID = new SelectList(db.job, "jobID", "description", jobPics.jobID);
            return View(jobPics);
        }

        // POST: jobPics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobID,before,after")] jobPics jobPics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobID = new SelectList(db.job, "jobID", "description", jobPics.jobID);
            return View(jobPics);
        }

        // GET: jobPics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobPics jobPics = db.jobPics.Find(id);
            if (jobPics == null)
            {
                return HttpNotFound();
            }
            return View(jobPics);
        }

        // POST: jobPics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            jobPics jobPics = db.jobPics.Find(id);
            db.jobPics.Remove(jobPics);
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
