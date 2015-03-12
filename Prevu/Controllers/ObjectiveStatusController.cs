using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prevu.Models;

namespace Prevu.Controllers
{
    public class ObjectiveStatusController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /ObjectiveStatus/

        public ActionResult Index()
        {
            var objectivestatuses = db.ObjectiveStatuses.Include(o => o.Objectives);
            return View(objectivestatuses.ToList());
        }

        //
        // GET: /ObjectiveStatus/Details/5

        public ActionResult Details(int id = 0)
        {
            ObjectiveStatus objectivestatus = db.ObjectiveStatuses.Find(id);
            if (objectivestatus == null)
            {
                return HttpNotFound();
            }
            return View(objectivestatus);
        }

        //
        // GET: /ObjectiveStatus/Create

        public ActionResult Create()
        {
            ViewBag.ObjectiveStatusId = new SelectList(db.Objectives, "ObjectiveId", "Name");
            return View();
        }

        //
        // POST: /ObjectiveStatus/Create

        [HttpPost]
        public ActionResult Create(ObjectiveStatus objectivestatus)
        {
            if (ModelState.IsValid)
            {
                db.ObjectiveStatuses.Add(objectivestatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObjectiveStatusId = new SelectList(db.Objectives, "ObjectiveId", "Name", objectivestatus.ObjectiveStatusId);
            return View(objectivestatus);
        }

        //
        // GET: /ObjectiveStatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ObjectiveStatus objectivestatus = db.ObjectiveStatuses.Find(id);
            if (objectivestatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObjectiveStatusId = new SelectList(db.Objectives, "ObjectiveId", "Name", objectivestatus.ObjectiveStatusId);
            return View(objectivestatus);
        }

        //
        // POST: /ObjectiveStatus/Edit/5

        [HttpPost]
        public ActionResult Edit(ObjectiveStatus objectivestatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objectivestatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObjectiveStatusId = new SelectList(db.Objectives, "ObjectiveId", "Name", objectivestatus.ObjectiveStatusId);
            return View(objectivestatus);
        }

        //
        // GET: /ObjectiveStatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ObjectiveStatus objectivestatus = db.ObjectiveStatuses.Find(id);
            if (objectivestatus == null)
            {
                return HttpNotFound();
            }
            return View(objectivestatus);
        }

        //
        // POST: /ObjectiveStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjectiveStatus objectivestatus = db.ObjectiveStatuses.Find(id);
            db.ObjectiveStatuses.Remove(objectivestatus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}