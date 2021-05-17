using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PFE.Repository;
using PFE.UseCase;
using Repository;

namespace PFE
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
            // ena zedt star hedha 
            services.AddTransient<IPictureRepository, PictureHttpRepository>();
            //kan tel9a constructeur bta3 usecase wala controller ye5ou param var de type IPictureRepository
            //esna3 objet PictureRepository wl variable param bta3 constructeur twali tpointi alih
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IBankCardRepository, BankCardRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IArticleUseCase, ArticleUseCase>();
            services.AddTransient<IUserUseCase, UserUseCase>();
            services.AddTransient<IOrderUseCase, OrderUseCase>();

            services.AddControllers();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
