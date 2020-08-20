using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW_8.DAL;
using HW_8.Models;
using HW_8.Models.ViewModel;

namespace HW_8.Controllers
{
    public class AthletesController : Controller
    {
        private HSTrackContext db = new HSTrackContext();

        // GET: Athletes
        public ActionResult Index()
        {
            var athletes = db.Athletes.Include(a => a.Team); 
            return View(athletes.ToList());
        }

        // GET: Athletes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete athlete = db.Athletes.Find(id);
            AthleteViewModel viewModel = new AthleteViewModel(athlete);
            if (athlete == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Athletes/Create
        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName");
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AthleteID,AthleteName,Gender,TeamID")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Athletes.Add(athlete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", athlete.TeamID);
            return View(athlete);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
