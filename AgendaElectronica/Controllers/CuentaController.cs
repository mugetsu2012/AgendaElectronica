using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Core.Services;
using AgendaElectronica.Extensions;
using AgendaElectronica.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaElectronica.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ISeguridadService _seguridadService;
        private readonly IUsuarioService _usuarioService;

        public CuentaController(ISeguridadService seguridadService, 
            IUsuarioService usuarioService)
        {
            _seguridadService = seguridadService;
            _usuarioService = usuarioService;
        }

        public IActionResult Login()
        {

            
            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"];
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Loguearse(LoginVm login)
        {
            bool loginValido = _seguridadService.LoginValido(login.NombreUsuario, login.Password);

            if (loginValido)
            {
                Usuario user = _usuarioService.GetUsuario(login.NombreUsuario);
                //Lo logueamos
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.NombreUsuario),
                    new Claim("FullName", user.NombreCompleto()),
                    new Claim(ClaimTypes.Role, user.IdRol.ToString())
                };

                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties authenticationProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authenticationProperties);


                //Lo mandamos a la lista de sus contactos
                return RedirectToAction("Index", "Contactos");
            }

            //Si el login no es valido, lo mando a la pagina del login nuevamente

            TempData["mensaje"] = "Las credenciales ingresadas no son correctas";

            return RedirectToAction("Login");

        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}