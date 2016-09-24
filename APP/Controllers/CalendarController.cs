using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Calendar";
            return View();}

     
    }
}