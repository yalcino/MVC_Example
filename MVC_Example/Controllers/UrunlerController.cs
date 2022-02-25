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
            return View();
        }

        [HttpPost]
        public ActionResult Yeniurun(TBLURUNLER p1)
        {
            db.TBLURUNLERs.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}