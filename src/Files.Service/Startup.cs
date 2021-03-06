using DocsDoc.Files.Service.Configuration;
using DocsDoc.Files.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DocsDoc.Files.Service
{
    public class Startup
    {
        private IConfigurationRoot ConfigRoot;

        public Startup(IConfiguration configRoot)
        {
            ConfigRoot = (IConfigurationRoot)configRoot;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(ctx => ConfigRoot.GetValue<FolderConfiguration>("FolderConfig"));

            services.AddImageAnalyzers();
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
                endpoints.MapGrpcService<FileService>();
            });
        }
    }
}
