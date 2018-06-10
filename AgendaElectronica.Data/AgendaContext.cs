using System;
using System.Collections.Generic;
using System.Text;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Data.Configs;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace AgendaElectronica.Data
{
    public class AgendaContext: DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options): base(options)
        {
            
        }

        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<Multimedia> Multimedias { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ContactoConfig());
            builder.ApplyConfiguration(new MultimediaConfig());
            builder.ApplyConfiguration(new RolConfig());
            builder.ApplyConfiguration(new UsuarioConfig());
        }
    }
}
