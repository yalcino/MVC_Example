using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Example.Models.Entity;

namespace MVC_Example.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLERs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult Yeniurun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILERs.ToList()
                                             select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString() }
                                           ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult Yeniurun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILERs.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLERs.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urn = db.TBLURUNLERs.Find(id);
            db.TBLURUNLERs.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UrunGetir(int id)
        {
            var m1 = db.TBLURUNLERs.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILERs.ToList()
                                             select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString() }
                               ).ToList();
            ViewBag.dgr = degerler;            

            return View("UrunGetir", m1);
        }

        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var m = db.TBLURUNLERs.Find(p1.URUNID);
            m.URUNAD = p1.URUNAD;
            m.MARKA = p1.MARKA;
            m.URUNKATEGORI = p1.TBLKATEGORILER.KATEGORIID;
            m.FIYAT = p1.FIYAT;
            m.STOK = p1.STOK;

            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}