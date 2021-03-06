using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Server.DataAccess.Agent;
using Server.DataAccess.Documents;
using Server.DataAccess.House;
using Server.DataAccess.Location;
using Server.DataAccess.Request.ShopRequest;
using Server.Services.Agent;
using Server.Services.Authentication;
using Server.Services.Document;
using Server.Services.House;
using Server.Services.Location;

using Server.Services.Request.ShopRequest;
using AutoMapper;
namespace Server.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            
            services.AddScoped<IAgentService,AgentService>();
            services.AddScoped<IAgentRepository,AgentRepository>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<ILocationService,LocationService>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IDocumentService,DocumentService>();
            services.AddScoped<IDocumentRepository,DocumentRepository>();
            services.AddScoped<IHouseTypeRepository,HouseTypeRepository>();
            services.AddScoped<IHouseTypeService,HouseTypeService>();
            services.AddScoped<IShopRequestRepository,ShopRequestRepository>();
            services.AddScoped<IShopRequestService,ShopRequestService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
