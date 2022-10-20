using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HettisentialMvc.MailClass;

namespace HettisentialMvc
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
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(options =>
                   options.UseMySQL(Configuration.GetConnectionString("ConnectionContext")));
            // Repositries
            services.AddScoped<IApplicationAdminRepo, ApplicationAdminRepo>();
            services.AddScoped<IApplicationUserRepo, ApplicationUserRepo>();
            services.AddScoped<IHospitAlRepo, HealthRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IUserRoleRepository, UserRoleRepo>();
            services.AddScoped<IImageRepo, ImageRepo>();

            services.AddScoped<IMedicalLabRepo, mMedicalLAbRepo>();

            services.AddScoped<IHealthCenteRRepo, HealthCenerRepo>();




            services.AddScoped<IPharmacyRepo, PharmacyRepo>();
            services.AddScoped<IAddressRepo, AddressRepo>();



            // Services
            services.AddScoped<IApplicationAdminService, AdministratorService>();
            services.AddScoped<IApplicationUSerService, ApplicationUSerService>();
            services.AddScoped<IHealthCenterService, HealthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPharmacyService, PharmacyServicee>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IImageService, IMageService>();

            services.AddScoped<IMedicalLabServices, MedicalLabServices>();
            services.AddScoped<IHealthCenerService, HEalhCenterService>();
   
             // Sendinblue
             services.AddScoped<IEmailService, Email >();
            // services.AddScoped<IEmail, mail>();

            //interface
          // services.AddScoped<  ITempDataDictionary , TempDataDictionary    >();

          // services.AddSingleton<  ITempDataDictionaryFactory  , TempDataDictionaryFactory   >();
            



            services.AddAuthentication();
            services.AddAuthorization();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(config =>
           {
               config.LoginPath = "/User/Login";
               config.Cookie.Name = "HetissentialApp";
               config.LogoutPath = "/User/Logout";
                 config.ExpireTimeSpan = TimeSpan.FromMinutes(240);
                 config.AccessDeniedPath = "/User/Login";
           });
            services.AddAuthorization();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
