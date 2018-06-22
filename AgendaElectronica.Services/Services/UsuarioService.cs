using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AgendaElectronica.Core;
using AgendaElectronica.Core.DTOs;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Core.Providers;
using AgendaElectronica.Core.Services;

namespace AgendaElectronica.Services.Services
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly ITextosProvider _textosProvider;
        private readonly IRepository<Multimedia> _multimediaRepository;
        private readonly IRepository<Contacto> _contactoRepository;
        private readonly string _claveEncriptar;

        public UsuarioService(IRepository<Usuario> usuarioRepository,
            ITextosProvider textosProvider, string claveEncriptar,
            IRepository<Multimedia> multimediaRepository,
            IRepository<Contacto> contactoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _textosProvider = textosProvider;
            _claveEncriptar = claveEncriptar;
            _multimediaRepository = multimediaRepository;
            _contactoRepository = contactoRepository;
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            _contactoRepository.Dispose();
            _multimediaRepository.Dispose();
        }

        public Usuario CrearUsuario(CrearEditarUsuarioDto crearEditarUsuario)
        {
            Usuario usuario = new Usuario()
            {
                Nombre = crearEditarUsuario.Nombre,
                Apellido = crearEditarUsuario.Apellido,
                IdRol = 1,
                NombreUsuario = crearEditarUsuario.NombreUsuario,
                Password = _textosProvider.EncriptarTexto(crearEditarUsuario.Password, _claveEncriptar)
            };

            _usuarioRepository.Insert(usuario);

            return usuario;
        }

        public Usuario EditarUsuario(CrearEditarUsuarioDto crearEditarUsuario, bool cambiarPassword)
        {
            Usuario usuario =
                _usuarioRepository.FindBy(x => x.NombreUsuario == crearEditarUsuario.NombreUsuario, null, true);

            usuario.Nombre = crearEditarUsuario.Nombre;
            usuario.Apellido = crearEditarUsuario.Apellido;
            usuario.Password = cambiarPassword
                ? _textosProvider.EncriptarTexto(crearEditarUsuario.Password, _claveEncriptar)
                : usuario.Password;

            _usuarioRepository.SaveChanges();

            return usuario;
        }

        public void EliminarUsuario(string nombreUsuario)
        {
            Usuario usuario = _usuarioRepository.FindBy(x => x.NombreUsuario == nombreUsuario,
                new Expression<Func<Usuario, object>>[]
                {
                    x => x.Contactos
                });

            foreach (Multimedia multimedia in usuario.Contactos.Select(y => y.Multimedia).ToList())
            {
                _multimediaRepository.Delete(multimedia, false);
            }

            foreach (Contacto contacto in usuario.Contactos)
            {
                _contactoRepository.Delete(contacto, false);
            }

            _usuarioRepository.Delete(usuario);
        }

        public List<Usuario> GetUsuarios()
        {
            return _usuarioRepository.GetList(x => x.NombreUsuario != "admin" && x.NombreUsuario != "anon",
                new Expression<Func<Usuario, object>>[] {x => x.Contactos, x => x.Rol});
        }

        public Usuario GetUsuario(string idUsuario)
        {
            return _usuarioRepository.FindBy(x => x.NombreUsuario == idUsuario,
                new Expression<Func<Usuario, object>>[] {x => x.Contactos});
        }
    }
}
