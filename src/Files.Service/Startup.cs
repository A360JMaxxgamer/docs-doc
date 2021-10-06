using DocsDoc.DocsAnalyzer;
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
        private readonly IConfigurationRoot _configuration;

        public Startup(IConfiguration configRoot)
        {
            _configuration = (IConfigurationRoot) configRoot;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseGrpcWeb();

            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapGrpcService<FileService>()
                    .EnableGrpcWeb(); 
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(_ => _configuration.GetValue<FolderConfiguration>("FolderConfig"));

            services.AddImageAnalyzers();
            services.AddGrpc();

            services.AddHttpClient("DocumentClient",
                client =>
                {
                    client.BaseAddress = _configuration.GetServiceUri("backend");
                });
        }
    }
}