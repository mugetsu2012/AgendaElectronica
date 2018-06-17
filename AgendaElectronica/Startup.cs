using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using AgendaElectronica.Core;
using AgendaElectronica.Core.Models;
using AgendaElectronica.Core.Providers;
using AgendaElectronica.Core.Services;
using AgendaElectronica.Data;
using AgendaElectronica.Services.Providers;
using AgendaElectronica.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaElectronica
{
    public class Startup
    {
        
        public Startup(IConfiguration config)
        {
            Configuration = config;
           
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Se piden datos de configuracion
            string connection = Configuration["ConnectionStrings:DefaultConnection"];
            string llaveEncript = Configuration["LlaveEncript"];

            //Sse agregan los servicios necesarios para funcionar con mvc
            services.AddDbContext<AgendaContext>(options => options.UseSqlServer(connection));
            services.AddScoped<DbContext, AgendaContext>();
            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                    options.Cookie.Name = "galletaAuth";
                });

            //Agregar servicios
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ITextosProvider, TextosProvider>();
            services.AddTransient<IContactosService, ContactosService>();

            services.AddTransient<ISeguridadService>(s =>
                new SeguridadService(textosProvider: s.GetService<ITextosProvider>(),
                    usuarioRepository: s.GetService<IRepository<Usuario>>(),
                    claveEncriptar: llaveEncript));


            services.AddTransient<IUsuarioService>(s => new UsuarioService(s.GetService<IRepository<Usuario>>(),
                s.GetService<ITextosProvider>(), llaveEncript, s.GetService<IRepository<Multimedia>>(),
                s.GetService<IRepository<Contacto>>()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

            
            //Comentarizar o descomentarizar para poder aplicar el seed
            //AgendaContext dbContext = app.ApplicationServices.GetRequiredService<AgendaContext>();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();


        }
    }
}
