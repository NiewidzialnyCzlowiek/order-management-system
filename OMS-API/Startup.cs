using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OMSAPI.DataContext;
using OMSAPI.Interfaces;
using OMSAPI.Services;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace OMSAPI
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
            services.AddCors();
            services.AddDbContext<OMSDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers()
                .AddNewtonsoftJson(setup => {
                    setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    setup.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICustomer, CustomerService>();
            services.AddScoped<IAddress, AddressService>();
            services.AddScoped<IItem, ItemService>();
            services.AddScoped<ISalesOrderHeader, SalesOrderHeaderService>();
            services.AddScoped<ISalesOrderLine, SalesOrderLineService>();
            services.AddScoped<IUnitOfMeasure, UnitOfMeasureService>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(corsPolicyBuilder =>
                corsPolicyBuilder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            );
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
