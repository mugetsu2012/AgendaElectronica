using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaElectronica.Core.Models
{
    public class Multimedia
    {
        public int Codigo { get; set; }

        public byte[] Archivo { get; set; }

        public string NombreArchivo { get; set; }

        public string Extension { get; set; }

        public string MimeType { get; set; }
    }
}
