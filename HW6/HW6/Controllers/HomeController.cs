using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW6.Models.ViewModel;
using HW6.DAL;
using System.Net;
using HW6.Models;

namespace HW6.Controllers
{
    public class HomeController : Controller
 
    {
        private WorldWideImportersContext db = new WorldWideImportersContext();

        public ActionResult Index(string q)
        {
            return View(db.StockItems.Where(s => s.StockItemName.Contains(q)).ToList());
        }

        public ActionResult Detail(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem StockItem = db.StockItems.Find(id);
            DetailViewModel viewModel = new DetailViewModel(StockItem);

            return View(viewModel);
        }
    }
}