using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloSeguridad.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult OperacionNoAutorizada(string operacion, string modulo, string error)
        {
            ViewBag.operacion = operacion;
            ViewBag.modulo = modulo;
            ViewBag.error = error;
            return View();
        }
    }
}