using Bookstore.Infrastructure.Data;
using Bookstore.Infrastructure.Repository;
using Bookstore.Infrastructure.Repository.Interface;
using Bookstore.Services;
using Bookstore.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookstore
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
            services.AddDbContext<BookstoreContext>(
                context => context.UseNpgsql(Configuration.GetConnectionString("DbContext"))
            );

            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            services.AddControllers().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            // Service
            services.AddScoped<ISignupService, SignupService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsApi");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
