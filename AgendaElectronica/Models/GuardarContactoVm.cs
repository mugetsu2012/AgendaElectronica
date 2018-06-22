using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaElectronica.Models
{
    public class GuardarContactoVm
    {
        [HiddenInput]
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
        [Phone]
        public string TelefonoMovil { get; set; }

        /// <summary>
        /// Telefono del trabajo, nullable
        /// </summary>
        [Phone]
        public string TelefonoTrabajo { get; set; }

        /// <summary>
        /// Email del contacto, nullable
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Imagen si es que el usuario desea subir una
        /// </summary>
        public IFormFile Imagen { get; set; }
    }
}
