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
    public class ActorController : Controller
    {
        private PrevuEntities db = new PrevuEntities();

        //
        // GET: /Actor/

        public ActionResult Index()
        {
            var actors = db.Actors.Include(a => a.ActorType);
            return View(actors.ToList());
        }

        //
        // GET: /Actor/Details/5

        public ActionResult Details(int id = 0)
        {
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            var children = actor.ChildActors.Select(c => c.ActorId);
            var possibleChildren = db.Actors.Where(a => a.Active == true && a.ActorId != actor.ActorId && !children.Contains(a.ActorId)).ToList();

            ViewData["childrenCount"] = possibleChildren.Count;
            ViewData["newChild"] = new SelectList(possibleChildren, "ActorId", "Name");
            return View(actor);
        }

        //
        // GET: /Actor/Create

        public ActionResult Create()
        {
            ViewBag.ActorTypeId = new SelectList(db.ActorTypes, "ActorTypeId", "Type");
            return View();
        }

        //
        // POST: /Actor/Create

        [HttpPost]
        public ActionResult Create(Actor actor)
        {
            actor.DateCreated = DateTime.Now;
            actor.DateModified = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorTypeId = new SelectList(db.ActorTypes, "ActorTypeId", "Type", actor.ActorTypeId);
            return View(actor);
        }

        //
        // GET: /Actor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorTypeId = new SelectList(db.ActorTypes, "ActorTypeId", "Type", actor.ActorTypeId);
            return View(actor);
        }

        //
        // POST: /Actor/Edit/5

        [HttpPost]
        public ActionResult Edit(Actor actor)
        {
            actor.DateModified = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorTypeId = new SelectList(db.ActorTypes, "ActorTypeId", "Type", actor.ActorTypeId);
            return View(actor);
        }

        //
        // GET: /Actor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // POST: /Actor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteChild(int parent, int child)
        {
            db.Actors.Find(parent).ChildActors.Remove(db.Actors.Find(child));
            db.SaveChanges();
            return RedirectToAction("Details", new { id = parent });
        }

        [HttpPost, ActionName("CreateChild")]
        public ActionResult CreateChild(int parent, int newChild)
        {
            db.Actors.Find(parent).ChildActors.Add(db.Actors.Find(newChild));
            db.SaveChanges();
            return RedirectToAction("Details", new { id = parent});
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}