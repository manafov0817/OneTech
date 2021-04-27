using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OneTech.Business.Abstract;
using OneTech.Business.Concrete;
using OneTech.Data.Abstract;
using OneTech.Data.Concrete.EfCore;
using OneTech.WebUi.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WepApi
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
            // Data
            services.AddScoped<IMainCategoryRepository, EfCoreMainCategoryRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ISubCategoryRepository, EfCoreSubCategoryRepository>();
            services.AddScoped<IBrandRepository, EfCoreBrandRepository>();
            services.AddScoped<IBrandModelRepository, EfCoreBrandModelRepository>();
            services.AddScoped<IOptionRepository, EfCoreOptionRepository>();
            services.AddScoped<IOptionValueRepository, EfCoreOptionValueRepository>();
            services.AddScoped<IRelateRepository, EfCoreRelateRepository>();
            services.AddScoped<IPhotoRepository, EfCorePhotoRepository>();
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<IProductRelateRepository, EfCoreProductRelateRepository>();
            services.AddScoped<ICartRepository, EfCoreCartRepository>();
            services.AddScoped<ICartItemRepository, EfCoreCartItemRepository>();
            services.AddScoped<IContactRepository, EfCoreContactRepository>();
            services.AddScoped<IBannerRepository, EfCoreBannerRepository>();
            services.AddScoped<IOnSaleProductRepository, EfCoreOnSaleProductRepository>();
            services.AddScoped<IFeaturedProductRepository, EfCoreFeaturedProductRepository>();
            services.AddScoped<IDealOfWeekProductRepository, EfCoreDealOfWeekProductRepository>();
            services.AddScoped<IBestRatedProductRepository, EfCoreBestRatedProductRepository>();
            services.AddScoped<IPopularCategoryRepository, EfCorePopularCategoryRepository>();

            services.AddScoped<IProductMainCategoryRepository, EfCoreProductMainCategoryRepository>();
            services.AddScoped<IProductCategoryRepository, EfCoreProductCategoryRepository>();
            services.AddScoped<IProductSubCategoryRepository, EfCoreProductSubCategoryRepository>();
            services.AddScoped<IProductOptionValueRepository, EfCoreProductOptionValueRepository>();
            services.AddScoped<IProductPhotoRepository, EfCoreProductPhotoRepository>();

            // Business
            services.AddScoped<IMainCategoryService, MainCategoryManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ISubCategoryService, SubCategoryManager>();
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandModelService, BrandModelManager>();
            services.AddScoped<IOptionService, OptionManager>();
            services.AddScoped<IOptionValueService, OptionValueManager>();
            services.AddScoped<IRelateService, RelateManager>();
            services.AddScoped<IPhotoService, PhotoManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductRelateService, ProductRelateManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICartItemService, CartItemManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IBannerService, BannerManager>();
            services.AddScoped<IOnSaleProductService, OnSaleProductManager>();
            services.AddScoped<IFeaturedProductService, FeaturedProductManager>();
            services.AddScoped<IDealOfWeekProductService, DealOfWeekProductManager>();
            services.AddScoped<IBestRatedProductService, BestRatedProductManager>();
            services.AddScoped<IPopularCategoryService, PopularCategoryManager>();

            services.AddScoped<IProductOptionValueService, ProductOptionValueManager>();
            services.AddScoped<IProductPhotoService, ProductPhotoManager>();
            services.AddScoped<IProductMainCategoryService, ProductMainCategoryManager>();
            services.AddScoped<IProductCategoryService, ProductCategoryManager>();
            services.AddScoped<IProductSubCategoryService, ProductSubCategoryManager>();

            services.AddDbContext<OneTechDbContext>(opions =>
            {
                opions
                .UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog = OneTechDbContext; Integrated Security = SSPI");
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedixxrection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
