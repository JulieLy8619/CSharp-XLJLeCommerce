using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models.Interfaces;
using XLJLeCommerce.Models.Services;
using XLJLeCommerce.Models;
using Microsoft.AspNetCore.Identity;
using XLJLeCommerce.Models.Handler;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace XLJLeCommerce
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {

            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbcontext>()
                    .AddDefaultTokenProviders();


            services.AddDbContext<CreaturesDbcontext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ProductionConnection"]));

            services.AddDbContext<ApplicationDbcontext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityDefaultConnection")));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Over3minOnly", policy => policy.Requirements.Add(new MinRegisterTimeRequirement()));
            });

            services.AddAuthentication()
             .AddMicrosoftAccount(microsoftOptions =>
             {
                 microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
                 microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:Password"];
             })
            .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<Iproduct, IproductManagementService>();
            services.AddScoped<ICart, ICartManagementService>();
            services.AddScoped<IShoppingCartItem, IShoppingCartItemManagementService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); //so can use stylesheet
            
            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });

           

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
