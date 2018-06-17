using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaElectronica.Core.DTOs
{
    public class CrearEditarContactoDto
    {
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Direccion { get; set; }

        public string TelTrabajo { get; set; }

        public string TelMovil { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Codigo del contacto, es 0 cuando es nuevo
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Codigo del usuario al que pertenece el contacto
        /// </summary>
        public string IdUsuario { get; set; }

    }
}
