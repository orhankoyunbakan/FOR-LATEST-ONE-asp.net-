using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOR_LATEST_ONE.Models;

namespace FOR_LATEST_ONE.Controllers
{
    public class KategoriController : Controller
    {
        ForLatestOne1Entities flo = new ForLatestOne1Entities();
        // GET: Kategori
        public ActionResult Index(int? menu_id, int? kategori_id)
        {
            var veri = flo.uruns.Where(x => x.kategori_id == kategori_id && x.menu_id == menu_id).ToList();
            return View(veri);
            
        }

        
    }
}