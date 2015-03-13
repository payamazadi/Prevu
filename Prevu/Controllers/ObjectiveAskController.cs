using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prevu.Models;

namespace Prevu.Controllers
{
    public class IssueObjectiveAsk
    {
        public Issue Issue { get; set; }
        public Objective Objective { get; set; }
        public Ask Ask { get; set; }
    }

    public class ObjectiveAskController : Controller
    {
        private PrevuEntities db = new PrevuEntities();
        //
        // GET: /ObjectiveAsk/

        public ActionResult Index()
        {
            var merged = from i in db.Issues
                         join o in db.Objectives on i.IssueId equals o.IssueId
                         join a in db.Asks on o.ObjectiveId equals a.ObjectiveId
                         select new { Issue = i, Objective = o, Ask = a };

            ViewBag.Items = merged.ToList().Select(x => new IssueObjectiveAsk
            {
                Issue = x.Issue,
                Objective = x.Objective,
                Ask = x.Ask,
            }).ToList();
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
