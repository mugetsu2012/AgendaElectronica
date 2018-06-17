using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaElectronica.Models
{
    public class Mensaje
    {
        public string Texto { get; set; }

        public TipoMensaje TipoMensaje { get; set; }
    }
}
