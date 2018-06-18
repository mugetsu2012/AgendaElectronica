using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgendaElectronica.Core.DTOs
{
    public class CrearEditarUsuarioDto
    {
        public CrearEditarUsuarioDto()
        {
            Password = "dummypass";
        }
        /// <summary>
        /// Codigo de la tabla, el nombre del usuario
        /// </summary>
        [Required(ErrorMessage = "El nombre dek usuario es requerido")]
        [MaxLength(100, ErrorMessage = "El Usuario del usuario no puede rebasar los 100 caracteres")]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Apellido del usuario
        /// </summary>
        [Required(ErrorMessage = "El Apellido del usuario es requerido")]
        [MaxLength(200, ErrorMessage = "El Apellido del usuario no puede rebasar los 200 caracteres")]
        public string Apellido { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        [MaxLength(200, ErrorMessage = "El Nombre del usuario no puede rebasar los 200 caracteres")]
        public string Nombre { get; set; }

        /// <summary>
        /// Password escogido por el usuario
        /// </summary>
        [Required(ErrorMessage = "La clave de acceso del usuario es requerida")]
        public string Password { get; set; }

    }
}
