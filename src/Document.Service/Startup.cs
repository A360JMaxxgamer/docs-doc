using DocsDoc.Documents.Service.GraphQl;
using DocsDoc.Documents.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;
using System;

namespace DocsDoc.Documents.Service
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDocumentService, ElasticDocumentService>();

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting();

            services
              .AddTransient<IElasticClient>(ctx =>
              {
                  var node = new Uri(_configuration.GetValue<string>("ElasticEndpoint"));
                  var settings = new ConnectionSettings(node)
                      .DefaultIndex("docs");
                  return new ElasticClient(settings);
              });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
