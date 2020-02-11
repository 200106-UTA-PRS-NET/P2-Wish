using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWish.DataAccess.Repositories;
using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MediaWish.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<MediaWishContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MediaWishDB")));

            // Adding Dependency to your Controller to use Db
            services.AddTransient<IUsersRepo, UsersRepo>();
            services.AddTransient<IMoviesRepo<DataAccess.Models.Movies, DataAccess.Models.MovieDetails>, MoviesRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Users}/{action=Info}/1"
                    );

                endpoints.MapControllers();
            });
        }
    }
}
