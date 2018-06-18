using System.Collections.Generic;
using AgendaElectronica.Core.DTOs;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaElectronica.Controllers
{
    public class UsuariosController: Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService, 
            ISeguridadService seguridadService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _usuarioService.GetUsuarios();
            return View(usuarios);
        }

        public IActionResult CrearEditar(string usuario = null)
        {
            Usuario user = _usuarioService.GetUsuario(usuario);
            return View(user);
        }

        [HttpPost]
        public IActionResult GuardarUsuario(CrearEditarUsuarioDto crearEditarUsuario, bool esNuevo) 
        {
            //Como es un nuevo registro, primero debo validar que no exista el usuario
            if (esNuevo)
            {
                Usuario user = _usuarioService.GetUsuario(crearEditarUsuario.NombreUsuario);

                //Ya existe un usuario con el normbre de usuario digitado
                if (user != null)
                {
                    return Json(new {exito = false, mensaje = "Ya existe un registro con el nombre de usuario ingresado"});
                }

                _usuarioService.CrearUsuario(crearEditarUsuario);

                return Json(new {exito = true});
            }
            else
            {
                //Como estamos editando, no puede cambiarse el usuario, no valido eso

                //Veo si modifico su password, asi la vuelvo a encriptar
                bool requiereCambiarPass = crearEditarUsuario.Password != "dummypass";
                _usuarioService.EditarUsuario(crearEditarUsuario, requiereCambiarPass);
                return Json(new { exito = true });
            }
        }

        [HttpPost]
        public IActionResult EliminarUsuario(string usuario)
        {
            _usuarioService.EliminarUsuario(usuario);
            return Json(new {exito = true});
        }
    }
}
