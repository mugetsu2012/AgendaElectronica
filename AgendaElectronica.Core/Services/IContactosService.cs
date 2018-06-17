using System;
using System.Collections.Generic;
using System.Text;
using AgendaElectronica.Core.DTOs;
using AgendaElectronica.Core.Models;

namespace AgendaElectronica.Core.Services
{
    public interface IContactosService:IDisposable
    {
        /// <summary>
        /// Permite crear un contacto, no crea la fotografia
        /// </summary>
        /// <param name="crearEditarContacto"></param>
        /// <returns></returns>
        Contacto CrearContacto(CrearEditarContactoDto crearEditarContacto);

        /// <summary>
        /// Permite editar un contacto, no agrega la fotografia
        /// </summary>
        /// <param name="crearEditarContacto"></param>
        /// <returns></returns>
        Contacto EditarContacto(CrearEditarContactoDto crearEditarContacto);

        /// <summary>
        /// Para un contacto existente, agrega o actualiza su fotografia
        /// </summary>
        /// <param name="idContacto"></param>
        /// <param name="multimedia"></param>
        void AgregarImagenContacto(int idContacto, Multimedia multimedia);

        /// <summary>
        /// Regresa la lista de contactos de un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        List<Contacto> GetContactos(string idUsuario);

        /// <summary>
        /// Ve el detalle especifico de un contacto
        /// </summary>
        /// <param name="idContacto"></param>
        /// <returns></returns>
        Contacto GetContacto(int idContacto);

        /// <summary>
        /// Indica que quiero eliminar un contacto
        /// </summary>
        /// <param name="idCodigo"></param>
        /// <param name="idUsuario"></param>
        void EliminarContacto(int idCodigo, string idUsuario);

        /// <summary>
        /// Obtiene una multimedia
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Multimedia GetMultimedia(int codigo);
    }
}
