using MediaWish.DataAccess.Repositories;
using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "MediaWish API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 

            /*
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(options => {
                options.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
            */

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "MediaWish API");
            });
            //

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}"
                    );

                endpoints.MapControllers();
            });
        }
    }
}
