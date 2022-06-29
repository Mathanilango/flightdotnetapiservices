using Adminservice.Interface;
using AutoMapper;
using Adminservice.DBContext;
using Adminservice.Interface;
using Adminservice.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly IAdmin _admin;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mappercfng = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperDetails());
            });
            IMapper Imap = mappercfng.CreateMapper();
            //rabitcns rabt = new rabitcns(_admin);
            //rabt.rabbitcns();
            services.AddSingleton(Imap);
            services.AddScoped<IAdmin, SqlAdminRepository>();
           // @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FlightBooking; MultipleActiveResultSets=True; Trusted_Connection=True; Integrated Security=True;"
            services.AddDbContextPool<AppDBContext>(options =>
           options.UseSqlServer(@"Data Source=flightbookings.database.windows.net; Initial Catalog=FlightBooking;User Id=flightbooking;Password=flight@6521")
           );
            services.AddMvc();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(op =>
                {
                    op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                });
            services.AddSwaggerGen(pt =>
            {
                pt.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using Bearer scheme(\"bearer {token}\")",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });
                pt.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddHostedService<TicketConsumer>();
            services.AddHostedService<TicketCancelconsumer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
