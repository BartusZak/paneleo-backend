using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using paneleo.BL.Services;
using paneleo.BL.Services.Interfaces;
using paneleo.Data.Data;
using paneleo.Share.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace paneleo.WebApi
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
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<User>();
            services.AddScoped<IUserStore<User>, UserOnlyStore<User, DataContext>>();
            services.AddAuthentication("Identity.Application")
                .AddCookie("Identity.Application");

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Events.OnRedirectToLogin = ctx =>
                {
                    if (ctx.Response.StatusCode == 200)
                    {
                        ctx.Response.StatusCode = 401;
                        return Task.FromResult<object>(null);
                    }
                    return Task.CompletedTask;
                };

                opt.Events.OnRedirectToAccessDenied = ctx => {
                    if (ctx.Response.StatusCode == 200)
                    {
                        ctx.Response.StatusCode = 403;
                        return Task.FromResult<object>(null);
                    }
                    return Task.CompletedTask;
                };

                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                opt.ExpireTimeSpan = TimeSpan.FromDays(1);
            });

            services.AddScoped<IAccountService, AccountService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Paneleo API", Version = "v1" });
            });

            //services.AddCors();

            services.AddMvc();

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
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials());
            //app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paneleo API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();

        }
    }
}
