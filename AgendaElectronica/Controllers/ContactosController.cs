using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AgendaElectronica.Core.DTOs;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Core.Services;
using AgendaElectronica.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaElectronica.Controllers
{
    public class ContactosController:Controller
    {
        private readonly IContactosService _contactosService;
        private readonly IMapper _mapper;

        public ContactosController(IContactosService contactosService,
            IMapper mapper)
        {
            _contactosService = contactosService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //Recupero la lista de contactos del usuario logueado o del usuario autenticado
            List<Contacto> contactos =
                _contactosService.GetContactos(User.Identity.IsAuthenticated ? User.Identity.Name : "anon");
            return View(contactos);
        }

        public IActionResult CrearEditar(int codigo = 0)
        {
            Contacto contacto = codigo == 0 ? new Contacto() : _contactosService.GetContacto(codigo);

            GuardarContactoVm guardarContacto = _mapper.Map<GuardarContactoVm>(contacto);
            return View(guardarContacto);
        }

        [HttpPost]
        public IActionResult GuardarContacto(GuardarContactoVm guardarContacto)
        {
            CrearEditarContactoDto crearEditarContacto = new CrearEditarContactoDto()
            {
                IdUsuario = User.Identity.IsAuthenticated ? User.Identity.Name : "anon",
                Codigo = guardarContacto.Codigo ?? 0,
                Nombres = guardarContacto.Nombre,
                Apellidos = guardarContacto.Apellido,
                Email = guardarContacto.Email,
                TelMovil = guardarContacto.TelefonoMovil,
                Direccion = guardarContacto.Direccion,
                TelTrabajo = guardarContacto.TelefonoTrabajo
            };

            //Dependiendo de si estamos creando o editanto
            Contacto contacto = guardarContacto.Codigo == null || guardarContacto.Codigo.Value == 0
                ? _contactosService.CrearContacto(crearEditarContacto)
                : _contactosService.EditarContacto(crearEditarContacto);


            if (guardarContacto.Imagen != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    guardarContacto.Imagen.CopyTo(ms);

                    Multimedia multimedia = new Multimedia()
                    {
                        Archivo = ms.ToArray(),
                        Extension = Path.GetExtension(guardarContacto.Imagen.FileName),
                        MimeType = guardarContacto.Imagen.ContentType,
                        NombreArchivo = guardarContacto.Imagen.FileName
                    };

                    _contactosService.AgregarImagenContacto(contacto.Codigo, multimedia);

                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EliminarContacto(int idContacto)
        {
            _contactosService.EliminarContacto(idContacto, User.Identity.IsAuthenticated ? User.Identity.Name : "anon");
            return RedirectToAction("Index");
        }

        public IActionResult GetUrlImagen(int idMultimedia)
        {
            Multimedia multimedia = _contactosService.GetMultimedia(idMultimedia);

            return multimedia == null ? null : File(multimedia.Archivo, multimedia.MimeType);
        }
    }   
}
