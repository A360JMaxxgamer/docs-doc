using System;
using DocsDoc.Documents.Service.GraphQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;

namespace DocsDoc.Documents.Service
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseWebSockets();
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting()
                .ConfigureResolverCompiler(r => { r.AddService<IElasticClient>(); });

            services
                .AddTransient<IElasticClient>(_ =>
                {
                    var node = new Uri(_configuration.GetValue<string>("ElasticEndpoint"));
                    var settings = new ConnectionSettings(node)
                        .DefaultIndex("docs");
                    return new ElasticClient(settings);
                });
        }
    }
}