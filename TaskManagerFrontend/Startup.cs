using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TaskManagerFrontend {
    public class Startup {
        IConfiguration configuration;
        public Startup(IConfiguration configuration) {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services) {

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
