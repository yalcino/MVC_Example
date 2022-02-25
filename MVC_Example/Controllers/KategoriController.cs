using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Example.Models.Entity;


namespace MVC_Example.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStockEntities db = new MvcDbStockEntities();

        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILERs.ToList();
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
            db.TBLKATEGORILERs.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}