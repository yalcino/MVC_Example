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
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILERs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult Yenimusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yenimusteri(TBLMUSTERILER p1)
        {
            db.TBLMUSTERILERs.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}