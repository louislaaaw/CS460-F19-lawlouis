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
using Newtonsoft.Json.Linq;

namespace HW_8.Controllers
{
    public class TeamsController : Controller
    {
        private HSTrackContext db = new HSTrackContext();

        // GET: Teams
        public ActionResult Index()
        {
            var teams = db.Teams.Include(t => t.Coach);
            return View(teams.ToList());
        }

/*        public JsonResult TeamJSON(Team team)
        {
            
        }*/

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
