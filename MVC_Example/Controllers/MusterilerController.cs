using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Example.Models.Entity;

namespace MVC_Example.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index( string p)
        {
            var degerler = from d in db.TBLMUSTERILERs select d;
            degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            //var degerler = db.TBLMUSTERILERs.ToList();
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult Yenimusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yenimusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid) return View("Yenimusteri");
            db.TBLMUSTERILERs.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var ms = db.TBLMUSTERILERs.Find(id);
            db.TBLMUSTERILERs.Remove(ms);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var ms = db.TBLMUSTERILERs.Find(id);            
            return View("MusteriGetir",ms);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var ms = db.TBLMUSTERILERs.Find(p1.MUSTERID);
            ms.MUSTERID = p1.MUSTERID;
            ms.MUSTERIAD = p1.MUSTERIAD;
            ms.MUSTERISOYAD= p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}