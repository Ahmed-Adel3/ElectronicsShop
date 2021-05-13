using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace ElectronicsShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders(); ;

            //services.AddLocalization(options => options.ResourcesPath = "Resources");

            //services.AddMvc();
            //.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => { opts.ResourcesPath = "Resources"; })
            //.AddDataAnnotationsLocalization(options =>
            //{
            //    options.DataAnnotationLocalizerProvider = (type, factory) =>
            //    {
            //        var assemblyName = new AssemblyName(typeof(SharedResources).GetTypeInfo().Assembly.FullName);
            //        return factory.Create("SharedResources", assemblyName.Name);
            //    };
            //});

            var DbConn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(DbConn, builder => builder.MigrationsAssembly("DataAccessLayer")));

            services.AddScoped<IUnitOfWork, UnitOfWork>().Cast<IUnitOfWork>();
            services.AddAuthentication();

            services.AddMvc()
            .AddControllersAsServices()
            .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null); //prevent property names from lowecasing in API response;

            services.AddRazorPages();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //            var cultureSupported = new[]
            //{
            //                new CultureInfo("en"),
            //                new CultureInfo("ar")
            //            };

            //            var requestLocalizationOptions = new RequestLocalizationOptions
            //            {
            //                DefaultRequestCulture = new RequestCulture("en", "ar"),
            //                SupportedCultures = cultureSupported,
            //                SupportedUICultures = cultureSupported
            //            };
            //            requestLocalizationOptions.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async httpContext => { return new ProviderCultureResult("en", "ar"); }));
            //            app.UseRequestLocalization(requestLocalizationOptions);

            app.UseAuthentication();
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
