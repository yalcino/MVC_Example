using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Example.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MVC_Example.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStockEntities db = new MvcDbStockEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLKATEGORILERs.ToList();
            var degerler = db.TBLKATEGORILERs.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid) return View("YeniKategori");
            db.TBLKATEGORILERs.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORILERs.Find(id);
            db.TBLKATEGORILERs.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORILERs.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var kategori = db.TBLKATEGORILERs.Find(p1.KATEGORIID);
            kategori.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}