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
    public class EventStatusController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /EventStatus/

        public ActionResult Index()
        {
            return View(db.EventStatus1.ToList());
        }

        //
        // GET: /EventStatus/Details/5

        public ActionResult Details(int id = 0)
        {
            EventStatus eventstatus = db.EventStatus1.Find(id);
            if (eventstatus == null)
            {
                return HttpNotFound();
            }
            return View(eventstatus);
        }

        //
        // GET: /EventStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EventStatus/Create

        [HttpPost]
        public ActionResult Create(EventStatus eventstatus)
        {
            if (ModelState.IsValid)
            {
                db.EventStatus1.Add(eventstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventstatus);
        }

        //
        // GET: /EventStatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EventStatus eventstatus = db.EventStatus1.Find(id);
            if (eventstatus == null)
            {
                return HttpNotFound();
            }
            return View(eventstatus);
        }

        //
        // POST: /EventStatus/Edit/5

        [HttpPost]
        public ActionResult Edit(EventStatus eventstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventstatus);
        }

        //
        // GET: /EventStatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EventStatus eventstatus = db.EventStatus1.Find(id);
            if (eventstatus == null)
            {
                return HttpNotFound();
            }
            return View(eventstatus);
        }

        //
        // POST: /EventStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EventStatus eventstatus = db.EventStatus1.Find(id);
            db.EventStatus1.Remove(eventstatus);
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