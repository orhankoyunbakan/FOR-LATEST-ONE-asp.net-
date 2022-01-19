using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOR_LATEST_ONE.Models;

namespace FOR_LATEST_ONE.Controllers
{
    public class FavorisController : Controller
    {
        // GET: Favoris
        ForLatestOne1Entities flo = new ForLatestOne1Entities();

        public ActionResult Index()
        {
           var  uye_id = Convert.ToInt32(Session["uye_id"]);
            
            var veri = flo.favoris.Where(x => x.uye_id == uye_id).ToList();

            return View(veri);
        }

        public ActionResult FavoriEkleme(favori f,int ? urun_id)
        {
            var uye_id = Convert.ToInt32(Session["uye_id"]); 

            f.urun_id = urun_id;
            f.uye_id = uye_id;
            
                flo.favoris.Add(f);
                flo.SaveChanges();
   
            return RedirectToAction("Index");

        }

        public ActionResult FavoriSilme(int  favori_id)
        {
            favori f= flo.favoris.Find(favori_id);

                flo.favoris.Remove(f);
                flo.SaveChanges();

        
            return RedirectToAction("Index");

        }


    }
}