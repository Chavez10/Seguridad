using ModuloSeguridad.Controllers;
using ModuloSeguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ModuloSeguridad.Filters
{
    public class Autorizaciones : AuthorizeAttribute
    {
        string OperacionNombre = "";
        string Modulo = "";
        private USUARIO user;
        private SEG_NUEVOEntities data = new SEG_NUEVOEntities();
        private int operar;

        public Autorizaciones(int codOperacion = 0)
        {
            this.operar = codOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            try
            {
                user = (USUARIO)HttpContext.Current.Session["user"];
                var misOperaciones = from dt in data.ROL_OPERA
                                     where dt.COD_ROL == user.COD_ROL
                                     && dt.COD_OPERA == operar
                                     select dt;
                if(misOperaciones.ToList().Count < 1)
                {
                    var operas = data.OPERACIONES.Find(operar);
                    int? codigoModulo = operas.COD_MOD;
                    OperacionNombre = getNombOperacion(operar);
                    Modulo = getNomModulos(codigoModulo);
                    filterContext.Result = new RedirectResult("~/Error/OperacionNoAutorizada?operacion="
                        +OperacionNombre+ ", modulo="+Modulo+", error=No_se_Autoriza");
                }
            }
            catch(Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/OperacionNoAutorizada?operacion="
                        + OperacionNombre + ", modulo=" + Modulo + ", error=No_se_Autoriza");
            }
        }

        private string getNomModulos(int? codigoModulo)
        {
            string nomMod;
            var mod = from mode in data.MODULO
                      where mode.COD_MOD == codigoModulo
                      select mode.NOM_MOD;

            try
            {
                nomMod = mod.First();
            }
            catch (Exception)
            {
                nomMod = "";
            }

            return nomMod;
        }

        private string getNombOperacion(int operar)
        {
            string nomOpr;
            var opr = from oper in data.OPERACIONES
                      where oper.COD_OPERA == operar
                      select oper.NOM_OPERA;

            try
            {
                nomOpr = opr.First();
            }
            catch (Exception)
            {
                nomOpr = "";
            }

            return nomOpr;
        }
        
    }
}