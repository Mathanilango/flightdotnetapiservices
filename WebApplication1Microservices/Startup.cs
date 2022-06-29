using CacheManager.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace WebApplication1Microservices
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment Ev)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Ev.ContentRootPath)
            .AddJsonFile("Configuration.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            confg = builder.Build();


        }
        public IConfigurationRoot confg { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Action<ConfigurationBuilderCachePart> sett = (x) =>
            {
                x.WithMicrosoftLogging(log =>
                {
                    log.AddConsole(LogLevel.Debug);
                }).WithDictionaryHandle();
            };
            //services.AddOcelot(confg, sett);
            //options.AddPolicy("Flight", pt => pt.AllowAnyOrigin());
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
        //    services.AddCors(options =>
        //    {
                
        //        options.AddPolicy("AnotherPolicy",
        //policy =>
        //{
        //    policy.AllowAnyOrigin()
        //    .WithHeaders(HeaderNames.ContentType, "application/json")
        //    .AllowAnyMethod()
        //    .AllowAnyHeader();

        //});


        //    });
            services.AddOcelot(confg);
           

            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(z => { z.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); } );
            //app.UseCors(t => t.WithHeaders(HeaderNames.ContentType, "text/plain"));
            //app.UseCors(s => s.AllowAnyMethod());
           // app.UseCors(s => s.AllowAnyHeader());
            await app.UseOcelot();
            
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
