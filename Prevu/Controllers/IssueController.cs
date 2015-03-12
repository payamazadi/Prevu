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
    public class IssueController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /Issue/

        public ActionResult Index()
        {
            var issues = db.Issues.Include(i => i.Staff);
            return View(issues.ToList());
        }

        //
        // GET: /Issue/Details/5

        public ActionResult Details(int id = 0)
        {
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        //
        // GET: /Issue/Create

        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName");
            return View();
        }

        //
        // POST: /Issue/Create

        [HttpPost]
        public ActionResult Create(Issue issue)
        {
            issue.DateModified = DateTime.Now;
            issue.DateCreated = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Issues.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", issue.OwnerId);
            return View(issue);
        }

        //
        // GET: /Issue/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", issue.OwnerId);
            return View(issue);
        }

        //
        // POST: /Issue/Edit/5

        [HttpPost]
        public ActionResult Edit(Issue issue)
        {
            issue.DateModified = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", issue.OwnerId);
            return View(issue);
        }

        //
        // GET: /Issue/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        //
        // POST: /Issue/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Issue issue = db.Issues.Find(id);
            db.Issues.Remove(issue);
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