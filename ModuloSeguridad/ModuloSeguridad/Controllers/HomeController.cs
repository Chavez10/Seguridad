using ModuloSeguridad.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloSeguridad.Controllers
{
    public class HomeController : Controller
    {
        [Autorizaciones (codOperacion: 1)]
        public ActionResult Index()
        {
            return View();
        }

        [Autorizaciones(codOperacion: 0)]
        public ActionResult Usuarios()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Autorizaciones(codOperacion: 4)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}