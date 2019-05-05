using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSTU.App.Data.Domain;
using KSTU.ClusterAnalysis.BLL.Interfaces;
using KSTU.ClusterAnalysis.BLL.Services;
using KSTU.Common.Interfaces;
using KSTU.Common.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KSTU.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationContext>(c =>
            {
                try
                {
                    c.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection"), x => x.MigrationsAssembly("KSTU.App.Data"));
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }
            });

            services.AddScoped<IKMeans, KMeans>();
            services.AddScoped<IFileService, FileService>();

            services.AddMvc(options =>
            {
                options.MaxModelValidationErrors = 50;
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((_) => "the field is required");
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
