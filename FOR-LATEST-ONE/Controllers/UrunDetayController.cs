using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOR_LATEST_ONE.Models;


namespace FOR_LATEST_ONE.Controllers
{
    public class UrunDetayController : Controller
    {
        ForLatestOne1Entities flo = new ForLatestOne1Entities();


        // GET: UrunDetay
        public ActionResult Index(int ? urun_id)
        {
            Session["urun_id"] = urun_id;
            var veri = flo.uruns.Where(x => x.urun_id == urun_id).ToList();
            return View(veri);
            

        }

       

       

        public ActionResult Yorum(int? urun_id)
        {
            var veri = flo.yorums.Where(x => x.urun_id == urun_id).ToList();
            return View(veri);
        }

        

        [HttpGet]
        public PartialViewResult YorumEkle()
        {
           
            return PartialView();
        }

        [HttpPost]
        public ActionResult YorumEkle(yorum y)
        {
            flo.yorums.Add(y);
            flo.SaveChanges();
            return PartialView();
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YorumEkle([Bind(Include = "yorum_id,uye_id,urun_id,yorum_detay,yorum_zaman,yorum_adsoyad")] yorum yorum)
        {

            if (ModelState.IsValid)
            {

                flo.yorums.Add(yorum);
                flo.SaveChanges();
                return RedirectToAction("index?urun_id="+@Session["urun_id"], "UrunDetay");
            }
            return View(yorum);
        }
        */

        public ActionResult EnYeniler()
        {
            var veri = flo.sliders.ToList();
            return View(veri);
        }


    }
}