using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pets.Core.Query.Context;
using System;

namespace Pets.Core.Application
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
            var assembly = AppDomain.CurrentDomain.Load("Pets.Core.Query");
            services.AddMediatR(assembly);
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Pets Application", Version = "v1 Alpha" });
            });
            services.AddMvc(opt =>
            {
                opt.EnableEndpointRouting = false;
            }).AddNewtonsoftJson()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).ConfigureApiBehaviorOptions(c =>
            {
                c.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbContext<PetsDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PetsDb"), sql =>
                {
                    sql.EnableRetryOnFailure();
                });
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetsApplication");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
