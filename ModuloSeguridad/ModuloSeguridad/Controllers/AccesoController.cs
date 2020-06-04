using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloSeguridad.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            try
            {
                using (Models.SEG_NUEVOEntities db = new Models.SEG_NUEVOEntities())
                {
                    var usu = (
                        from datos in db.USUARIO 
                        where datos.EMAIL == user.Trim()
                        && datos.PASSWORD == pass.Trim()
                        && datos.COD_ESTADO == 1
                        select datos
                        ).FirstOrDefault();

                    if(usu == null)
                    {
                        ViewBag.Error = "Credenciales invalidas o usuario no existe";
                        return View();
                    }else
                    {
                        Session["user"] = usu;
                        
                    }
                    return RedirectToAction("Index", "Home");
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}