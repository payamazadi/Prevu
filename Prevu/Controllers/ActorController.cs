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

            /*Throwaway code for testing*/
            string temp = "";
            var parents = actor.ParentActors.ToList();
            if (parents.Count > 0)
            {
                temp += "Member of:<br>";
                foreach (var parent in parents)
                    temp += parent.Name.ToString() + "<br>";
            }

            var children = actor.ChildActors.ToList();
            if (children.Count > 0)
            {
                temp += "<br><br>Children:<br>";
                foreach (var child in children)
                    temp += child.Name.ToString() + "<br>";
            }

            ViewBag.children = temp;
            /***/

            
            /*
            db.Actors.Find(7).ChildActors.Add(db.Actors.Find(6));
            db.SaveChanges();
            */
            
             
            return View(actor);
        }

        //
        // GET: /Actor/Create

        public ActionResult Create()
        {
            ViewBag.ActorTypeId = new SelectList(db.ActorTypes, "ActorTypeId", "Name");
            return View();
        }

        //
        // POST: /Actor/Create

        [HttpPost]
        public ActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorTypeId = new SelectList(db.ActorTypes, "ActorTypeId", "Name", actor.ActorTypeId);
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
            ViewBag.ActorTypeId = new SelectList(db.ActorTypes, "ActorTypeId", "Name", actor.ActorTypeId);
            return View(actor);
        }

        //
        // POST: /Actor/Edit/5

        [HttpPost]
        public ActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorTypeId = new SelectList(db.ActorTypes, "ActorTypeId", "Name", actor.ActorTypeId);
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}