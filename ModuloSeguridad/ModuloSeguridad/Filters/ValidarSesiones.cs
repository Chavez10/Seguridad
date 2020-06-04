using ModuloSeguridad.Controllers;
using ModuloSeguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloSeguridad.Filters
{
    public class ValidarSesiones : ActionFilterAttribute
    {
        private USUARIO usu;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                usu = (USUARIO)HttpContext.Current.Session["user"];
                if(usu == null)
                {
                    if(filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Acceso/Login");
                    }
                }
            }
            catch(Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

        }
    }
}