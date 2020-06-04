using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModuloSeguridad.Models;
using ModuloSeguridad.Models.VistaUsuariosModel;

namespace ModuloSeguridad.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            List<InfoUser> lista = null;

            using(SEG_NUEVOEntities data = new SEG_NUEVOEntities())
            {
                lista = (from info in data.USUARIO
                         where info.COD_ESTADO == 1
                         orderby info.EMAIL
                         select new InfoUser
                         {
                             COD_USER = info.COD_USER,
                             NOM_USER = info.NOMBRE,
                             MAIL_USER = info.EMAIL,
                             COD_ROL = info.COD_ROL,
                             COD_ESTADO = info.COD_ESTADO
                         }).ToList();
                return View(lista);
            }
        }
    }
}