using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaElectronica.Core.DTOs;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaElectronica.Controllers
{
    public class UsuariosController: Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ISeguridadService _seguridadService;

        public UsuariosController(IUsuarioService usuarioService, 
            ISeguridadService seguridadService)
        {
            _usuarioService = usuarioService;
            _seguridadService = seguridadService;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _usuarioService.GetUsuarios();
            return View(usuarios);
        }
    }
}
