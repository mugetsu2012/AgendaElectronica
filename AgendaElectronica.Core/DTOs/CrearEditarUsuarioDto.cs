using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaElectronica.Core.DTOs
{
    public class CrearEditarUsuarioDto
    {
        /// <summary>
        /// Codigo de la tabla, el nombre del usuario
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Apellido del usuario
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Password escogido por el usuario
        /// </summary>
        public string Password { get; set; }

    }
}
