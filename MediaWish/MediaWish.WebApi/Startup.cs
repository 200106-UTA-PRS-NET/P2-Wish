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


using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

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
        readonly string AllMyOrigins = "_allMyOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddControllers(options =>
            {
                /*
                 By default, when the framework detects that the request is coming from a browser:
                        The Accept header is ignored. The content is returned in JSON, unless otherwise configured*/
                options.RespectBrowserAcceptHeader = true; // false by default
            });

            services.AddDbContext<MediaWishContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MediaWishDB")));

            // Adding Dependency to your Controller to use Db
            services.AddTransient<IUsersRepo, UsersRepo>();

            // Register the Swagger generator, defining 1 or more Swagger documents

            services.AddSwaggerGen(options =>

            {

                options.SwaggerDoc("v1", new OpenApiInfo { Title = "MediaWish Api", Version = "v1" });

            });

            services.AddCors(options =>
            {
                options.AddPolicy(AllMyOrigins, b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddTransient<IMoviesRepo<DataAccess.Models.MovieAPI, DataAccess.Models.MovieDetails>, MoviesRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
             }
            


            // Enable middleware to serve generated Swagger as a JSON endpoint.

            var swaggerOptions = new SwaggerOptions();

            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(options =>
            {

                options.RouteTemplate = swaggerOptions.JsonRoute;

            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.

            app.UseSwaggerUI(options =>
            {

                //options.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerOptions.Description);

                options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);

            });
            //
            app.UseCors(AllMyOrigins);
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
