using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.BL;
using API.DAL;
using API.Entities;
using API.Helpers;
using API.interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _config.GetConnectionString("default");
            services.AddDbContext<DataContext>(c => c.UseSqlServer(connectionString));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<ITaskBL, TaskBL>();
            services.AddScoped<ITaskDAL,TaskDAL>();
            services.AddScoped<ITypeBL, TypeBL>();
            services.AddScoped<ITypeDAL,TypeDAL>();
            services.AddScoped<TaskDAL>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddCors(options => options.AddPolicy("AllowOrigin", p => p.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowOrigin");

            app.UseHttpsRedirection();

             app.UseMvc();

        }
    }
}
