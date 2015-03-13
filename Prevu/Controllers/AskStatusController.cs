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
    public class AskStatusController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /AskStatus/

        public ActionResult Index()
        {
            return View(db.AskStatuses.ToList());
        }

        //
        // GET: /AskStatus/Details/5

        public ActionResult Details(int id = 0)
        {
            AskStatus askstatus = db.AskStatuses.Find(id);
            if (askstatus == null)
            {
                return HttpNotFound();
            }
            return View(askstatus);
        }

        //
        // GET: /AskStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AskStatus/Create

        [HttpPost]
        public ActionResult Create(AskStatus askstatus)
        {
            if (ModelState.IsValid)
            {
                db.AskStatuses.Add(askstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(askstatus);
        }

        //
        // GET: /AskStatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AskStatus askstatus = db.AskStatuses.Find(id);
            if (askstatus == null)
            {
                return HttpNotFound();
            }
            return View(askstatus);
        }

        //
        // POST: /AskStatus/Edit/5

        [HttpPost]
        public ActionResult Edit(AskStatus askstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(askstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(askstatus);
        }

        //
        // GET: /AskStatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AskStatus askstatus = db.AskStatuses.Find(id);
            if (askstatus == null)
            {
                return HttpNotFound();
            }
            return View(askstatus);
        }

        //
        // POST: /AskStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AskStatus askstatus = db.AskStatuses.Find(id);
            db.AskStatuses.Remove(askstatus);
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