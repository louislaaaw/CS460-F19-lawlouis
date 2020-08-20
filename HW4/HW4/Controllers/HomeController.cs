using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        
        // GET /Home/RGBColor
        [HttpGet]
        public ActionResult RGBColor()
        {
            ViewBag.R = Request.QueryString["Red"];
            ViewBag.G = Request.QueryString["Green"];
            ViewBag.B = Request.QueryString["Blue"];

            return View();
        }
        public ActionResult Clicked()
        {
            ViewBag.R = Request.QueryString["Red"];
            ViewBag.G = Request.QueryString["Green"];
            ViewBag.B = Request.QueryString["Blue"];
            return Redirect("/Home/RGBColor?Red=" + ViewBag.R + "&Green=" + ViewBag.G + "&Blue=" + ViewBag.B);
        }
    }
}