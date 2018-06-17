using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaElectronica.Core.Services
{
    public interface ISeguridadService:IDisposable
    {
        /// <summary>
        /// Para una password y usuario indica si el login es valido
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        bool LoginValido(string usuario, string passWord);
    }
}
