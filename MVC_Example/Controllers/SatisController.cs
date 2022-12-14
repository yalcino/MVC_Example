using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Example.Models.Entity;

namespace MVC_Example.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStockEntities db = new MvcDbStockEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View("Index");
        }


        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p1)
        {
            db.TBLSATISLARs.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    }
}