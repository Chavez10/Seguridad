using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ModuloSeguridad.Models.CRUD
{
    public class UserViewCrud
    {
        [Required]
        public int COD_USER { get; set; }
        /* --------- */
        [Required]
        public string NOM_USER { get; set; }
        /* --------- */
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage ="No cumple el tamaño", MinimumLength =1)]
        public string MAIL_USER { get; set; }
        /* --------- */
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string PASS_USER { get; set; }
        /* --------- */
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("PASS_USER", ErrorMessage ="Las Contraseñas no son iguales")]
        public string CONFIRM_PASS_USER { get; set; }
        /* --------- */
        [Required]
        public int? COD_ESTADO { get; set; }
    }
}