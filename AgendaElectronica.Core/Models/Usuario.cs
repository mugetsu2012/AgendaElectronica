using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaElectronica.Core.Models
{
    public class Usuario
    {
        /// <summary>
        /// Usuario, es la llave
        /// </summary>
        public string NombreUsuario { get; set; }

        public int IdRol { get; set; }

        /// <summary>
        /// nombre del usuario, not null
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del usuario, not null
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Password encriptado 
        /// </summary>
        public byte[] Password { get; set; }

        /// <summary>
        /// Lista de contactos de este usuario
        /// </summary>
        public List<Contacto> Contactos { get; set; }

        /// <summary>
        /// Rol del usuario
        /// </summary>
        public Rol Rol { get; set; }
    }
}
