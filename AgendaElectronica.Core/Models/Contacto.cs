using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaElectronica.Core.Models
{
    public class Contacto
    {
        /// <summary>
        /// Llave del contacto
        /// </summary>
        public int Codigo { get; set; }

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
        /// Codigo del usuario al que pertenece este contacto
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Codigo de la multimedia para este contacto, es opcional
        /// </summary>
        public int? IdMultimedia { get; set; }

        /// <summary>
        /// Usuario al que pertenece este contacto
        /// </summary>
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Objeto multimedia, es opcional
        /// </summary>
        public Multimedia Multimedia { get; set; }
    }
}
