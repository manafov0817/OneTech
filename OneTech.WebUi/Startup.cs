using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OneTech.Business.Abstract;
using OneTech.Business.Concrete;
using OneTech.Data.Abstract;
using OneTech.Data.Concrete.EfCore;
using OneTech.WebUi.EmailServices;
using OneTech.WebUi.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi
{
    public class Startup
    {
        public Startup ( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices ( IServiceCollection services )
        {

            // Data
            services.AddScoped<IMainCategoryRepository, EfCoreMainCategoryRepository>( );
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>( );
            services.AddScoped<ISubCategoryRepository, EfCoreSubCategoryRepository>( );
            services.AddScoped<IBrandRepository, EfCoreBrandRepository>( );
            services.AddScoped<IBrandModelRepository, EfCoreBrandModelRepository>( );
            services.AddScoped<IOptionRepository, EfCoreOptionRepository>( );
            services.AddScoped<IOptionValueRepository, EfCoreOptionValueRepository>( );
            services.AddScoped<IPhotoRepository, EfCorePhotoRepository>( );
            services.AddScoped<IProductRepository, EfCoreProductRepository>( );
            services.AddScoped<ICartRepository, EfCoreCartRepository>( );

            services.AddScoped<IProductMainCategoryRepository, EfCoreProductMainCategoryRepository>( );
            services.AddScoped<IProductCategoryRepository, EfCoreProductCategoryRepository>( );
            services.AddScoped<IProductSubCategoryRepository, EfCoreProductSubCategoryRepository>( );
            services.AddScoped<IProductOptionValueRepository, EfCoreProductOptionValueRepository>( );
            services.AddScoped<IProductPhotoRepository, EfCoreProductPhotoRepository>( );

            // Business
            services.AddScoped<IMainCategoryService, MainCategoryManager>( );
            services.AddScoped<ICategoryService, CategoryManager>( );
            services.AddScoped<ISubCategoryService, SubCategoryManager>( );
            services.AddScoped<IBrandService, BrandManager>( );
            services.AddScoped<IBrandModelService, BrandModelManager>( );
            services.AddScoped<IOptionService, OptionManager>( );
            services.AddScoped<IOptionValueService, OptionValueManager>( );
            services.AddScoped<IPhotoService, PhotoManager>( );
            services.AddScoped<IProductService, ProductManager>( );
            services.AddScoped<ICartService, CartManager>( );

            services.AddScoped<IProductOptionValueService, ProductOptionValueManager>( );
            services.AddScoped<IProductPhotoService, ProductPhotoManager>( );
            services.AddScoped<IProductMainCategoryService, ProductMainCategoryManager>( );
            services.AddScoped<IProductCategoryService, ProductCategoryManager>( );
            services.AddScoped<IProductSubCategoryService, ProductSubCategoryManager>( );


            services.AddScoped<OneTechDbContext>( );

            services.AddDbContext<ApplicationContext>(opions =>
            {
                opions
                .UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog = OneTechDbContext; Integrated Security = SSPI");
            });

            services.AddIdentity<User, IdentityRole>( )
                        .AddEntityFrameworkStores<ApplicationContext>( )
                        .AddDefaultTokenProviders( );

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;


                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(5);
                options.Lockout.AllowedForNewUsers = true;

                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Admin/Account/Login";
                options.LogoutPath = "/Admin/Account/Logout";
                options.AccessDeniedPath = "/Home/Error";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(45);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".OneTech.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };

            });
            services.AddScoped<IProductRepository, EfCoreProductRepository>( );

            services.AddScoped<IProductService, ProductManager>( );
            services.AddScoped<IEmailSender, SmtpEmailSender>(sender =>
            new SmtpEmailSender(
                 Configuration["EmailSender:Host"],
                 Configuration.GetValue<int>("EmailSender:Port"),
                 Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                 Configuration["EmailSender:UserName"],
                 Configuration["EmailSender:Password"])
            );
            services.AddControllersWithViews( );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure ( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if (env.IsDevelopment( ))
            {
                //SeedDatabase.Seed( );
                app.UseDeveloperExceptionPage( );
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts( );
            }
            app.UseHttpsRedirection( );
            app.UseStaticFiles( );
            app.UseAuthentication( );
            app.UseRouting( );

            app.UseAuthorization( );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
