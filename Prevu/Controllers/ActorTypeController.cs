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
    public class ActorTypeController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /ActorType/

        public ActionResult Index()
        {
            return View(db.ActorTypes.ToList());
        }

        //
        // GET: /ActorType/Details/5

        public ActionResult Details(int id = 0)
        {
            ActorType actortype = db.ActorTypes.Find(id);
            if (actortype == null)
            {
                return HttpNotFound();
            }
            return View(actortype);
        }

        //
        // GET: /ActorType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ActorType/Create

        [HttpPost]
        public ActionResult Create(ActorType actortype)
        {
            actortype.DateCreated = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                db.ActorTypes.Add(actortype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actortype);
        }

        //
        // GET: /ActorType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ActorType actortype = db.ActorTypes.Find(id);
            if (actortype == null)
            {
                return HttpNotFound();
            }
            return View(actortype);
        }

        //
        // POST: /ActorType/Edit/5

        [HttpPost]
        public ActionResult Edit(ActorType actortype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actortype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actortype);
        }

        //
        // GET: /ActorType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ActorType actortype = db.ActorTypes.Find(id);
            if (actortype == null)
            {
                return HttpNotFound();
            }
            return View(actortype);
        }

        //
        // POST: /ActorType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ActorType actortype = db.ActorTypes.Find(id);
            db.ActorTypes.Remove(actortype);
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