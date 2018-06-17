using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaElectronica.Models
{
    public class LoginVm
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Su password es requerido")]
        public string Password { get; set; }
    }
}
