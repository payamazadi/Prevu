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
    public class ObjectiveController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /Objective/

        public ActionResult Index()
        {
            var objectives = db.Objectives.Include(o => o.Issue).Include(o => o.ObjectiveStatus).Include(o => o.Staff);
            return View(objectives.ToList());
        }

        //
        // GET: /Objective/Details/5

        public ActionResult Details(int id = 0)
        {
            Objective objective = db.Objectives.Find(id);
            if (objective == null)
            {
                return HttpNotFound();
            }
            return View(objective);
        }

        //
        // GET: /Objective/Create

        public ActionResult Create()
        {
            ViewBag.IssueId = new SelectList(db.Issues, "IssueId", "Name");
            ViewBag.ObjectiveStatusId = new SelectList(db.ObjectiveStatuses, "ObjectiveStatusId", "Name");
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName");
            return View();
        }

        //
        // POST: /Objective/Create

        [HttpPost]
        public ActionResult Create(Objective objective)
        {
            if (ModelState.IsValid)
            {
                db.Objectives.Add(objective);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IssueId = new SelectList(db.Issues, "IssueId", "Name", objective.IssueId);
            ViewBag.ObjectiveStatusId = new SelectList(db.ObjectiveStatuses, "ObjectiveStatusId", "Name", objective.ObjectiveStatusId);
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", objective.OwnerId);
            return View(objective);
        }

        //
        // GET: /Objective/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Objective objective = db.Objectives.Find(id);
            if (objective == null)
            {
                return HttpNotFound();
            }
            ViewBag.IssueId = new SelectList(db.Issues, "IssueId", "Name", objective.IssueId);
            ViewBag.ObjectiveStatusId = new SelectList(db.ObjectiveStatuses, "ObjectiveStatusId", "Name", objective.ObjectiveStatusId);
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", objective.OwnerId);
            return View(objective);
        }

        //
        // POST: /Objective/Edit/5

        [HttpPost]
        public ActionResult Edit(Objective objective)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objective).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IssueId = new SelectList(db.Issues, "IssueId", "Name", objective.IssueId);
            ViewBag.ObjectiveStatusId = new SelectList(db.ObjectiveStatuses, "ObjectiveStatusId", "Name", objective.ObjectiveStatusId);
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", objective.OwnerId);
            return View(objective);
        }

        //
        // GET: /Objective/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Objective objective = db.Objectives.Find(id);
            if (objective == null)
            {
                return HttpNotFound();
            }
            return View(objective);
        }

        //
        // POST: /Objective/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Objective objective = db.Objectives.Find(id);
            db.Objectives.Remove(objective);
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