using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FOR_LATEST_ONE.Models;

namespace FOR_LATEST_ONE.Controllers
{
    public class LogController : Controller
    {
        private ForLatestOne1Entities db = new ForLatestOne1Entities();


        public ActionResult Cikis()
        {
            Session["uye_ad"] = null;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(uye Model)
        {
            var uye = db.uyes.FirstOrDefault(x => x.uye_mail == Model.uye_mail && x.uye_password == Model.uye_password);
            if (uye != null)
            {
                Session["uye_ad"] = uye.uye_ad.ToUpper();
                Session["uye_mail"] = uye.uye_mail;
                Session["uye_id"] = uye.uye_id;
                Session["uye_adsoyad"] = uye.uye_ad.ToUpper()+ uye.uye_soyad.ToUpper();
                if (uye.uye_yetki == 5)
                {
                    return RedirectToAction("IndexFilm", "Films");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Hata = (" Email ya da şifre yanlış!!!");

            return View();
        }

        public ActionResult Kayitol()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kayitol([Bind(Include = "uye_id,uye_ad,uye_soyad,uye_mail,uye_password")] uye uye)
        {
            if (ModelState.IsValid && uye != null)
            {

                uye.uye_yetki = 1;
                db.uyes.Add(uye);
                db.SaveChanges();
                ViewBag.Kayitok = ("Kaydınız Tamamlandı Giriş Yapabilirisiniz.");
                return RedirectToAction("Kayitol", "Log");
            }
            ViewBag.Kayitno = ("Kaydınız Tamamlanmadı Tekrar Deneyiniz.");
            return View(uye);

        }





        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////





       
    }
}
