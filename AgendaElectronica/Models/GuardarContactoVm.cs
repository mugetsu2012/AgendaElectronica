using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AgendaElectronica.Models
{
    public class GuardarContactoVm
    {
        public int? Codigo { get; set; }

        /// <summary>
        /// Nombre del contacto, not null
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// apellido del contacto, nullable
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Direccion del contacto, nullable
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Telefono movil, nullable
        /// </summary>
        public string TelefonoMovil { get; set; }

        /// <summary>
        /// Telefono del trabajo, nullable
        /// </summary>
        public string TelefonoTrabajo { get; set; }

        /// <summary>
        /// Email del contacto, nullable
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Imagen si es que el usuario desea subir una
        /// </summary>
        public IFormFile Imagen { get; set; }
    }
}
