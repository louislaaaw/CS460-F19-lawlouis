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

namespace HW_8.Controllers
{
    public class ResultsController : Controller
    {
        private HSTrackContext db = new HSTrackContext();

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.AthleteID = new SelectList(db.Athletes, "AthleteID", "AthleteName");
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Location");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResultID,AthleteID,EventID,Time")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.AthleteID = new SelectList(db.Athletes, "AthleteID", "AthleteName", result.AthleteID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Location", result.EventID);
            return View(result);
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
