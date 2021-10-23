using Infrastrucer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using Infrastrucer.Repositry;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Infrastrucer.Models;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace Bisnicity
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(opt => opt.ResourcesPath= "Resources");
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            services.Configure<RequestLocalizationOptions>(opt => {
                var supported = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("ar")

                };
                opt.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                opt.SupportedCultures = supported;
                opt.SupportedUICultures = supported;
                
            });
            services.AddControllers();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyBisnicityDB"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(option =>
           {
               option.User.RequireUniqueEmail = true;
               //option.SignIn.RequireConfirmedEmail = true;
              //option.SignIn.RequireConfirmedEmail = true;
           }).AddRoles<IdentityRole>().AddEntityFrameworkStores<DataContext>()
           .AddDefaultTokenProviders();
            //services.AddMailKit(Opt=>Opt.UseMailKit(configuration.GetSection("Email").Get<MailKitOptions>()));
            services.AddRazorPages();
            services.AddScoped<IBisnicity<Info>, InfoDBRepo>();
            services.AddScoped<IBisnicity<OurServices>, OurServicedbRepo>();
            services.AddScoped<IBisnicity<Templete>, TempleteDbRepo>();
            services.AddScoped<IBisnicity<Services>, ServicesDbRepo>();
            services.AddScoped<IBisnicity<CatTemp>, CategoryRepo>();
            services.AddScoped<IBisnicity<jobVacancy>, JobVacancyRepo>();
            services.AddScoped<IBisnicity<Gender>, GenderRepo>();
            services.AddScoped<IBisnicity<Educationlevel>, EducationlevelRepo>();
            services.AddScoped<IBisnicity<Person>, PersonRepo>();
            services.AddScoped<IBisnicity<CatPerson>, CatPersonRepo>();
            services.AddScoped<IBisnicity<DetailsPerson>, DetailsPersonRepo>();
            services.AddScoped<IBisnicity<SkillsPerson>, SkillPersonRepo>();
            services.AddScoped<IBisnicity<Univircity>, univircityRepo>();
            services.AddScoped<IBisnicity<DataPerson>, DataPersonRepo>();
            services.AddScoped<IBisnicity<PostCompany>, postRepo>();
            services.AddScoped<IBisnicity<Idea>, IdeaRepo>();
            services.AddScoped<IBisnicity<SuppourtIdea>, SupportIdeaRepo>();
            services.AddScoped<IBisnicity<Targetsector>, TargetSectorRepo>();
            services.AddScoped<IBisnicity<TypeCompany>, TypeCompRepo>();
            services.AddScoped<IBisnicity<yourstatus>, yourstatusRepo>();
            services.AddScoped<IBisnicity<CareerPath>, CareerPathRepo>();
            services.AddScoped<IBisnicity<Datavocational>, DataVocationalRepo>();
            services.AddScoped<IBisnicity<ContactUs>, ContactUsRepo>();
            services.AddScoped<IBisnicity<Invistor>, InvistorRepo>();
            services.AddScoped<IBisnicity<ContactUs>, ContactUsRepo>();
            services.AddScoped<IBisnicity<ApplayJob>, applayjobRepo>();
            services.AddScoped<IBisnicity<volunteer>, volunteerRepo>();
            services.AddScoped<IBisnicity<TypeIdea>, TypeIdeaRepo>();


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
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
            CreateRoles(serviceProvider).Wait();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            var LocOP = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(LocOP.Value);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    "defultRoute",
                    "{controller=Home}/{action=Index1}/{id?}"
                    );
            });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                // ensure that the role does not exist
                if (!roleExist)
                {
                    //create the roles and seed them to the database: 
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // find the user with the admin email 
            var _user = await UserManager.FindByEmailAsync("admin@email.com");

            // check if the user exists
            if (_user == null)
            {
                //Here you could create the super admin who will maintain the web app
                var poweruser = new ApplicationUser
                {
                    UserName = "admin@email.com",
                    Email = "admin@email.com",
                    sFirstname="Samer",
                    sLastname="Safi",
                    
                };
                string adminPassword = "Samer@141295";

                var createPowerUser = await UserManager.CreateAsync(poweruser, adminPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }

        }
    }
}
