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
    public class DizisController : Controller
    {
        private ForLatestOne1Entities db = new ForLatestOne1Entities();

        public ActionResult IndexDizi()
        {
            var uruns = db.uruns.Where(x => x.menu_id == 2).ToList();
            return View(uruns.ToList());
        }


       
        public ActionResult CreateDizi()
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
        public ActionResult CreateDizi([Bind(Include = "urun_id,ad,menu_id,kategori_id,aciklama,yonetmen,yapim_yili,oyuncular,foto_url,yayin_kanal,bolum_sayisi,son_surum,yukleme_sayisi,boyut,yayin_evi,sayfa_sayisi,sozler,sanatci,tur,yazar")] urun urun)
        {
            if (ModelState.IsValid)
            {
                urun.menu_id = 2;
                db.uruns.Add(urun);
                db.SaveChanges();
                return RedirectToAction("IndexDizi");
            }

            ViewBag.kategori_id = new SelectList(db.kategoris, "kategori_id", "kategori_ad", urun.kategori_id);
            ViewBag.menu_id = new SelectList(db.menus, "menu_id", "menu_ad", urun.menu_id);
            return View(urun);
        }
        public ActionResult DetailsDizi(int? id)
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


        public ActionResult EditDizi(int? id)
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
        public ActionResult EditDizi([Bind(Include = "urun_id,ad,menu_id,kategori_id,aciklama,yonetmen,yapim_yili,oyuncular,foto_url,yayin_kanal,bolum_sayisi,son_surum,yukleme_sayisi,boyut,yayin_evi,sayfa_sayisi,sozler,sanatci,tur,yazar")] urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexDizi");
            }
            ViewBag.kategori_id = new SelectList(db.kategoris, "kategori_id", "kategori_ad", urun.kategori_id);
            ViewBag.menu_id = new SelectList(db.menus, "menu_id", "menu_ad", urun.menu_id);
            return View(urun);
        }


        public ActionResult DeleteDizi(int? id)
        {
            urun urun = db.uruns.Find(id);
            db.uruns.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("IndexDizi");

        }
    }
}
