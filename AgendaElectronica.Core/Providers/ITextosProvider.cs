using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaElectronica.Core.Providers
{
    /// <summary>
    /// Provider con metodos para poder encriptar/desencriptar texto
    /// </summary>
    public interface ITextosProvider
    {
        /// <summary>
        /// Metodo que permite encriptar un texto haciendo uso de una clave
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        string EncriptarTexto(string texto, string clave);

        /// <summary>
        /// Metodo que permite descriptar un texto, debe proporcionarse la clave con la cual se
        /// ecntripto el texto
        /// </summary>
        /// <param name="textoEncriptado"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        string DesencriptarTexto(string textoEncriptado, string clave);
    }
}
