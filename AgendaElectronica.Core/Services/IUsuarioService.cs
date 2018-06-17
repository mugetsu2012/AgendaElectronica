using System;
using System.Collections.Generic;
using System.Text;
using AgendaElectronica.Core.DTOs;
using AgendaElectronica.Core.Models;

namespace AgendaElectronica.Core.Services
{
    public interface IUsuarioService: IDisposable
    {
        /// <summary>
        /// Metodo para crear un usuario, valida que no exista un usuario con el mismo nombre de usuario
        /// </summary>
        /// <remarks>Internamente hace uso de un provider para encriptar la password</remarks>
        /// <param name="crearEditarUsuario"></param>
        /// <returns></returns>
        Usuario CrearUsuario(CrearEditarUsuarioDto crearEditarUsuario);

        /// <summary>
        /// Metodo utilizado para editar un usuario existente, indica si se quiere cambiar o no el password
        /// </summary>
        /// <param name="crearEditarUsuario"></param>
        /// <param name="cambiarPassword"></param>
        /// <returns></returns>
        Usuario EditarUsuario(CrearEditarUsuarioDto crearEditarUsuario, bool cambiarPassword);

        /// <summary>
        /// Elimina de la faz de la historia la informacion de usuario, sus contactos y multimedias
        /// </summary>
        /// <param name="nombreUsuario"></param>
        void EliminarUsuario(string nombreUsuario);

        /// <summary>
        /// Obtiene la lista de usuarios
        /// </summary>
        /// <returns></returns>
        List<Usuario> GetUsuarios();

        /// <summary>
        /// Obtiene un usuario especifico
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Usuario GetUsuario(string idUsuario);
    }
}
