using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AgendaElectronica.Core;
using AgendaElectronica.Core.DTOs;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Core.Services;

namespace AgendaElectronica.Services.Services
{
    public class ContactosService: IContactosService
    {
        private readonly IRepository<Contacto> _contactoRepository;
        private readonly IRepository<Multimedia> _multimediaRepository;

        public ContactosService(IRepository<Contacto> contactoRepository, 
            IRepository<Multimedia> multimediaRepository)
        {
            _contactoRepository = contactoRepository;
            _multimediaRepository = multimediaRepository;
        }

        public void Dispose()
        {
            _contactoRepository.Dispose();
            _multimediaRepository.Dispose();
        }

        public Contacto CrearContacto(CrearEditarContactoDto crearEditarContacto)
        {
            Contacto contacto = new Contacto()
            {
                Nombre = crearEditarContacto.Nombres,
                Apellido = crearEditarContacto.Apellidos,
                IdUsuario = crearEditarContacto.IdUsuario,
                Direccion = crearEditarContacto.Direccion,
                Email = crearEditarContacto.Email,
                TelefonoMovil = crearEditarContacto.TelMovil,
                TelefonoTrabajo = crearEditarContacto.TelTrabajo
            };

            _contactoRepository.Insert(contacto);

            return contacto;
        }

        public Contacto EditarContacto(CrearEditarContactoDto crearEditarContacto)
        {
            Contacto contacto = _contactoRepository.FindBy(x => x.Codigo == crearEditarContacto.Codigo, null, true);

            contacto.Nombre = crearEditarContacto.Nombres;
            contacto.Apellido = crearEditarContacto.Apellidos;
            contacto.Direccion = crearEditarContacto.Direccion;
            contacto.Email = crearEditarContacto.Email;
            contacto.TelefonoMovil = crearEditarContacto.TelMovil;
            contacto.TelefonoTrabajo = crearEditarContacto.TelTrabajo;

            _contactoRepository.SaveChanges();

            return contacto;
        }

        public void AgregarImagenContacto(int idContacto, Multimedia multimedia)
        {
            Contacto contacto = _contactoRepository.FindBy(x => x.Codigo == idContacto,
                new Expression<Func<Contacto, object>>[]
                {
                    x => x.Multimedia
                }, true);

            if (contacto.IdMultimedia == null)
            {
                contacto.Multimedia = multimedia;
            }
            else
            {
                contacto.Multimedia = multimedia;
            }

            _contactoRepository.SaveChanges();
        }

        public List<Contacto> GetContactos(string idUsuario)
        {
            return _contactoRepository.GetList(x => x.IdUsuario == idUsuario);
        }

        public Contacto GetContacto(int idContacto)
        {
            return _contactoRepository.FindBy(x => x.Codigo == idContacto);
        }

        public void EliminarContacto(int idCodigo, string idUsuario)
        {
            Contacto contacto = _contactoRepository.FindBy(x => x.Codigo == idCodigo, new Expression<Func<Contacto, object>>[]
            {
                x => x.Multimedia
            });

            if (contacto.IdUsuario != idUsuario)
            {
                throw new ArgumentException("Error, el contacto no pertenece al usuario");
            }

            _contactoRepository.Delete(contacto);
        }

        public Multimedia GetMultimedia(int codigo)
        {
            return _multimediaRepository.FindBy(x => x.Codigo == codigo);
        }
    }
}
