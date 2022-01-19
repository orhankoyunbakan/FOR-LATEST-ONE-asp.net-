using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOR_LATEST_ONE.Models;



namespace FOR_LATEST_ONE.Controllers
{
    public class HomeController : Controller
    {
        ForLatestOne1Entities flo = new ForLatestOne1Entities();
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Slider()
        {
            var veri = flo.sliders.ToList();
            return View(veri);
 
        }

        public ActionResult Diziler()
        {

            var veri = flo.uruns.Where(x => x.menu_id == 2).Take(8).ToList();
            return View(veri);
        }
        public ActionResult Filmler()
        {
            var veri = flo.uruns.Where(x => x.menu_id == 1).Take(8).ToList();
            return View(veri);
        }

        public ActionResult Kitaplar()
        {

            var veri = flo.uruns.Where(x => x.menu_id == 3).Take(8).ToList();
            return View(veri);
        }

        public ActionResult Oyunlar()
        {

            var veri = flo.uruns.Where(x => x.menu_id == 4).Take(8).ToList();
            return View(veri);
        }

        public ActionResult Muzikler()
        {

            var veri = flo.uruns.Where(x => x.menu_id == 5).Take(8).ToList();
            return View(veri);
        }

        public ActionResult Uygulamalar()
        {
            var uye_id =Convert.ToInt32( Session["uye_id"]);
            var veri = flo.uyes.Where(x => x.uye_id == uye_id).ToList();
            return View(veri);
        
        }

        public ActionResult Hesabim()
        {
            return View();
        }

        public ActionResult sp1()
        {
            var veri = flo.sp_sayfa_buyuk_500().ToList();
            return View(veri);
        }

        public ActionResult sp2()
        {
            var veri = flo.sp_buyil_cikan_hersey1().ToList();
            return View(veri);
        }


    }
}