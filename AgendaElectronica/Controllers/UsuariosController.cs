using System.Collections.Generic;
using AgendaElectronica.Core.DTOs;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AgendaElectronica.Controllers
{
    public class UsuariosController: Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public UsuariosController(IUsuarioService usuarioService, 
            ISeguridadService seguridadService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            if (PuedeVer())
            {
                List<Usuario> usuarios = _usuarioService.GetUsuarios();
                return View(usuarios);
            }

            return RedirectToAction("Login", "Cuenta");

        }

        public IActionResult CrearEditar(string usuario = null)
        {
            if (PuedeVer())
            {
                Usuario user = _usuarioService.GetUsuario(usuario) ?? new Usuario();

                CrearEditarUsuarioDto crearEditarUsuario = new CrearEditarUsuarioDto()
                {
                    Nombre = user.Nombre,
                    NombreUsuario = user.NombreUsuario,
                    Apellido = user.Apellido
                };

                return View(crearEditarUsuario);
            }

            return RedirectToAction("Login", "Cuenta");

        }

        [HttpPost]
        public IActionResult GuardarUsuario(CrearEditarUsuarioDto crearEditarUsuario, bool esNuevo) 
        {
            if (PuedeVer())
            {

                //Como es un nuevo registro, primero debo validar que no exista el usuario
                if (esNuevo)
                {
                    Usuario user = _usuarioService.GetUsuario(crearEditarUsuario.NombreUsuario);

                    //Ya existe un usuario con el normbre de usuario digitado
                    if (user != null)
                    {
                        return RedirectToAction("Index");
                    }

                    _usuarioService.CrearUsuario(crearEditarUsuario);

                    return RedirectToAction("Index");
                }
                else
                {
                    //Como estamos editando, no puede cambiarse el usuario, no valido eso

                    //Veo si modifico su password, asi la vuelvo a encriptar
                    bool requiereCambiarPass = !string.IsNullOrEmpty(crearEditarUsuario.Password);
                    _usuarioService.EditarUsuario(crearEditarUsuario, requiereCambiarPass);
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Login", "Cuenta");
        }

        [HttpPost]
        public IActionResult EliminarUsuario(string usuario)
        {
            if (PuedeVer())
            {
                _usuarioService.EliminarUsuario(usuario);
                return Json(new { exito = true });
            }

            return RedirectToAction("Login", "Cuenta");
        }

        private bool PuedeVer()
        {
            return User.Identity.IsAuthenticated == false || User.IsInRole("2");
        }
    }
}
