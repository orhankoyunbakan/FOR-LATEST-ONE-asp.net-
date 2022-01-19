using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOR_LATEST_ONE.Models;
namespace FOR_LATEST_ONE.Controllers
{
    public class SharedController : Controller
    {

        ForLatestOne1Entities flo = new ForLatestOne1Entities();

        // GET: Shared
        public ActionResult menu()
        {

            
            var veri = flo.kategoris.ToList();
            
            return View(veri);
        }


        public ActionResult _AdminLayout()
        {

            return View();
        }
    }
}