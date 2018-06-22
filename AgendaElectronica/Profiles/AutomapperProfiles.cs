using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Models;
using AutoMapper;

namespace AgendaElectronica.Profiles
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Contacto, GuardarContactoVm>().ReverseMap();
        }
    }
}
