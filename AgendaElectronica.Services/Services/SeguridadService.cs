using AgendaElectronica.Core;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Core.Providers;
using AgendaElectronica.Core.Services;

namespace AgendaElectronica.Services.Services
{
    public class SeguridadService: ISeguridadService
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly ITextosProvider _textosProvider;
        private readonly string _claveEncriptar;

        public SeguridadService(IRepository<Usuario> usuarioRepository,
            ITextosProvider textosProvider, string claveEncriptar)
        {
            _usuarioRepository = usuarioRepository;
            _textosProvider = textosProvider;
            _claveEncriptar = claveEncriptar;
        }
        
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        public bool LoginValido(string usuario, string passWord)
        {
            //Si envia algun campo en blaco
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(passWord))
            {
                return false;
            }

            Usuario user = _usuarioRepository.FindBy(x => x.NombreUsuario == usuario);

            //Si no existe el usuario
            if (user == null)
            {
                return false;
            }

            //En este punto el usuario existe, pero hay que ver que onda con su pass

            //Mando a cifrar la clave proporcionada
            string claveTentativa = _textosProvider.DesencriptarTexto(user.Password, _claveEncriptar);

            //Regresamos la comparacion de los passwords
            return claveTentativa == passWord;
        }

        
    }
}
