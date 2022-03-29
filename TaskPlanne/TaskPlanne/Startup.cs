using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanne.Aplicacao;
using TaskPlanne.Aplicacao._Interfaces;
using TaskPlanne.Persistencia.Armazem;
using TaskPlanne.Persistencia.BdContext;
using TaskPlanne.Persistencia.Interface;

namespace TaskPlanne
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskPlanne", Version = "v1" });
            });

            services.AddControllers()
           .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
               Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );

            services.AddDbContext<PlanilhaContext>(opc => opc.UseSqlServer(Configuration.GetConnectionString("ConexaoSql")));


            services.AddScoped<ITarefaServico, TarefaServico>();
            services.AddScoped<IQuadroDeTarefasServico, QuadroDeTarefasServico>();

            services.AddScoped<IGeralPersistencia, GeralPersistencia>();
            services.AddScoped<ITarefaPersistencia, TarefaPersistencia>();
            services.AddScoped<IQuadroDeTarefasPersistencia, QuadroDeTarefasPersistencia>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskPlanne v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
