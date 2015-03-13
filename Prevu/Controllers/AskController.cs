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
    public class AskController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /Ask/

        public ActionResult Index()
        {
            var asks = db.Asks.Include(a => a.AskStatus).Include(a => a.Staff).Include(a => a.Objective);
            return View(asks.ToList());
        }

        //
        // GET: /Ask/Details/5

        public ActionResult Details(int id = 0)
        {
            Ask ask = db.Asks.Find(id);
            if (ask == null)
            {
                return HttpNotFound();
            }
            return View(ask);
        }

        //
        // GET: /Ask/Create

        public ActionResult Create()
        {

            ViewBag.AskStatusId = new SelectList(db.AskStatuses, "AskStatusId", "Status");
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName");
            ViewBag.ObjectiveId = GetObjectiveSelect(0);
            return View();
        }

        //
        // POST: /Ask/Create

        [HttpPost]
        public ActionResult Create(Ask ask)
        {
            ask.DateModified = DateTime.Now;
            ask.DateCreated = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Asks.Add(ask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AskStatusId = new SelectList(db.AskStatuses, "AskStatusId", "Status", ask.AskStatusId);
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", ask.OwnerId);
            ViewBag.ObjectiveId = GetObjectiveSelect(ask.ObjectiveId);
            return View(ask);
        }

        //
        // GET: /Ask/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ask ask = db.Asks.Find(id);
            if (ask == null)
            {
                return HttpNotFound();
            }
            ViewBag.AskStatusId = new SelectList(db.AskStatuses, "AskStatusId", "Status", ask.AskStatusId);
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", ask.OwnerId);
            ViewBag.ObjectiveId = GetObjectiveSelect(ask.ObjectiveId);
            return View(ask);
        }

        //
        // POST: /Ask/Edit/5

        [HttpPost]
        public ActionResult Edit(Ask ask)
        {
            ask.DateModified = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(ask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AskStatusId = new SelectList(db.AskStatuses, "AskStatusId", "Status", ask.AskStatusId);
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", ask.OwnerId);
            ViewBag.ObjectiveId = GetObjectiveSelect(ask.ObjectiveId);
            return View(ask);
        }

        //
        // GET: /Ask/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ask ask = db.Asks.Find(id);
            if (ask == null)
            {
                return HttpNotFound();
            }
            return View(ask);
        }

        //
        // POST: /Ask/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ask ask = db.Asks.Find(id);
            db.Asks.Remove(ask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected SelectList GetObjectiveSelect(int selectedObjectiveId)
        {
            var select = db.Objectives.Select(p => new { ObjectiveId = p.ObjectiveId, Name = p.Issue.Name + " - " + p.Name }).OrderBy(q => q.Name);
            if(selectedObjectiveId == 0)
                return new SelectList(select, "ObjectiveId", "Name");
            return new SelectList(select, "ObjectiveId", "Name", selectedObjectiveId);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}