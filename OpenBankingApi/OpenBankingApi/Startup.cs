using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenBankingApi.Domain.Services;
using OpenBankingApi.Domain.Services.Interfaces;
using OpenBankingApi.Infrastructure;
using OpenBankingApi.Repository;
using OpenBankingApi.Repository.Interfaces;
using System;
using System.Text;

namespace OpenBankingApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Authorization
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "openBanking",
                    ValidAudience = "openBanking",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                };
            });
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<Contexto>(option => option.UseSqlServer(ConfigureConnectionString()));

            #region Injeçao de Dependência
            services.AddTransient<ITransacaoService, TransacaoService>();
            services.AddTransient<ITrasacaoRepository, TransacaoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IContaRepository, ContaRepository>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //loggerFactory.AddProvider(new LoggerDataBaseProvider());

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private string ConfigureConnectionString()
            => Configuration.GetConnectionString("Default").Replace("?path?", Environment.CurrentDirectory);
    }
}
