using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSHOP.DAL;
using WEBSHOP.DAL.Repositories.Implementations;
using WEBSHOP.DAL.Repositories.Interfaces;

namespace WEBSHOP
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
            services.AddRazorPages().AddRazorRuntimeCompilation();
            var connection = Configuration.GetConnectionString("StrConnection");
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseMySQL(connection);
                options.EnableSensitiveDataLogging(true);
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
                loggingBuilder.AddDebug();
            });
            services.AddScoped<IProductInterface, ProductRepository>();
            services.AddScoped<IBinInterface, BinRepository>();
            services.AddScoped<IUserInterface, UserRepository>();
            services.AddScoped<IManufactorerInterface, ManufactorerRepository>();
            services.AddScoped<IOrdersInterface, OrdersRepository>();
            services.AddScoped<IPaymentMethodInterface, PaymentMethodRepository>();
            services.AddScoped<IUnitInterface, UnitRepository>();
            services.AddScoped<ITypesInterface, TypesRepository>();
            services.AddHttpClient();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions =>
            {
                cookieOptions.LoginPath = "/";
            });
            services.AddMvc().AddRazorPagesOptions(options => {

                options.Conventions.AuthorizeFolder("/User");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
