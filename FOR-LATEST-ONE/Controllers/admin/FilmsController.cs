using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FOR_LATEST_ONE.Models;

namespace FOR_LATEST_ONE.Controllers.admin
{
    public class FilmsController : Controller
    {
        private ForLatestOne1Entities db = new ForLatestOne1Entities();

        public ActionResult IndexFilm()
        {
            var uruns = db.uruns.Where(x => x.menu_id == 1).ToList();
            return View(uruns.ToList());
        }


        // GET: uruns/Delete/5
       

        public ActionResult CreateFilm()
        {
            ViewBag.kategori_id = new SelectList(db.kategoris, "kategori_id", "kategori_ad");
            ViewBag.menu_id = new SelectList(db.menus, "menu_id", "menu_ad");
            return View();
        }

        // POST: uruns/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFilm([Bind(Include = "urun_id,ad,menu_id,kategori_id,aciklama,yonetmen,yapim_yili,oyuncular,foto_url,yayin_kanal,bolum_sayisi,son_surum,yukleme_sayisi,boyut,yayin_evi,sayfa_sayisi,sozler,sanatci,tur,yazar")] urun urun)
        {
            if (ModelState.IsValid)
            {
                urun.menu_id = 1;
                db.uruns.Add(urun);
                db.SaveChanges();
                return RedirectToAction("IndexFilm");
            }

            ViewBag.kategori_id = new SelectList(db.kategoris, "kategori_id", "kategori_ad", urun.kategori_id);
            ViewBag.menu_id = new SelectList(db.menus, "menu_id", "menu_ad", urun.menu_id);
            return View(urun);
        }
        public ActionResult DetailsFilm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            urun urun = db.uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }


        public ActionResult EditFilm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            urun urun = db.uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategori_id = new SelectList(db.kategoris, "kategori_id", "kategori_ad", urun.kategori_id);
            ViewBag.menu_id = new SelectList(db.menus, "menu_id", "menu_ad", urun.menu_id);
            return View(urun);
        }

        // POST: uruns/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFilm([Bind(Include = "urun_id,ad,menu_id,kategori_id,aciklama,yonetmen,yapim_yili,oyuncular,foto_url,yayin_kanal,bolum_sayisi,son_surum,yukleme_sayisi,boyut,yayin_evi,sayfa_sayisi,sozler,sanatci,tur,yazar")] urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexFilm");
            }
            ViewBag.kategori_id = new SelectList(db.kategoris, "kategori_id", "kategori_ad", urun.kategori_id);
            ViewBag.menu_id = new SelectList(db.menus, "menu_id", "menu_ad", urun.menu_id);
            return View(urun);
        }

        public ActionResult DeleteFilm(int? id)
        {
            urun urun = db.uruns.Find(id);
            db.uruns.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("IndexFilm");
            
        }



       
    }
}
