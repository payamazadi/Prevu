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
    public class StaffController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /Staff/

        public ActionResult Index()
        {
            var staffs = db.Staffs.Include(s => s.Department);
            return View(staffs.ToList());
        }

        //
        // GET: /Staff/Details/5

        public ActionResult Details(int id = 0)
        {
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        //
        // GET: /Staff/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
            return View();
        }

        //
        // POST: /Staff/Create

        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            staff.DateCreated = DateTime.Now;
            staff.DateModified = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", staff.DepartmentId);
            return View(staff);
        }

        //
        // GET: /Staff/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", staff.DepartmentId);
            return View(staff);
        }

        //
        // POST: /Staff/Edit/5

        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            staff.DateModified = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", staff.DepartmentId);
            return View(staff);
        }

        //
        // GET: /Staff/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        //
        // POST: /Staff/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.Staffs.Find(id);
            db.Staffs.Remove(staff);
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