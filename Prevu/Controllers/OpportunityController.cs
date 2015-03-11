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
    public class OpportunityController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /Opportunity/

        public ActionResult Index()
        {
            var opportunities = db.Opportunities.Include(o => o.EventStatu).Include(o => o.Staff);
            return View(opportunities.ToList());
        }

        //
        // GET: /Opportunity/Details/5

        public ActionResult Details(int id = 0)
        {
            Opportunity opportunity = db.Opportunities.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        //
        // GET: /Opportunity/Create

        public ActionResult Create()
        {
            ViewBag.EventStatusId = new SelectList(db.EventStatus1, "EventStatusId", "Name");
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName");
            return View();
        }

        //
        // POST: /Opportunity/Create

        [HttpPost]
        public ActionResult Create(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                db.Opportunities.Add(opportunity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventStatusId = new SelectList(db.EventStatus1, "EventStatusId", "Name", opportunity.EventStatusId);
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", opportunity.OwnerId);
            return View(opportunity);
        }

        //
        // GET: /Opportunity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Opportunity opportunity = db.Opportunities.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventStatusId = new SelectList(db.EventStatus1, "EventStatusId", "Name", opportunity.EventStatusId);
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", opportunity.OwnerId);
            return View(opportunity);
        }

        //
        // POST: /Opportunity/Edit/5

        [HttpPost]
        public ActionResult Edit(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opportunity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventStatusId = new SelectList(db.EventStatus1, "EventStatusId", "Name", opportunity.EventStatusId);
            ViewBag.OwnerId = new SelectList(db.Staffs, "StaffId", "FirstName", opportunity.OwnerId);
            return View(opportunity);
        }

        //
        // GET: /Opportunity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Opportunity opportunity = db.Opportunities.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        //
        // POST: /Opportunity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opportunity opportunity = db.Opportunities.Find(id);
            db.Opportunities.Remove(opportunity);
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