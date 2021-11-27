using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TaskManagetWebAPI.Model;
using TaskManagetWebAPI.DAL;

namespace TaskManagetWebAPI {
    public class Startup {
        IConfiguration configuration;
        public Startup(IConfiguration configuration) {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services) {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TaskContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
                options => options.WithOrigins("http://localhost:65007")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
            );
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
