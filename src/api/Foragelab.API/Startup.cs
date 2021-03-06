﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
//using Foragelab.Core.Data;
using Microsoft.EntityFrameworkCore;
using Foragelab.Core.DataModel;
using Foragelab.Core.DataModel.Repository;
using Foragelab.Core.Services.Interfaces;
using Foragelab.Core.Services.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Foragelab.API
{
    public class Startup
    {
        // secretKey contains a secret passphrase only your server knows
        private SymmetricSecurityKey JWTSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWTSecretKey"))); 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server = PEEYUSH_AGRAWAL; UID = sa; password = clarion; Initial Catalog = CVAS; MultipleActiveResultSets = true;";
            services.AddDbContext<CVASContext>(options => options.UseSqlServer(connection));
            //Add framework services.
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                           .AllowAnyMethod()
                                                                           .AllowAnyHeader()
                                                                           .WithExposedHeaders("X-Pagination")));

            services.AddAuthentication()
                    .AddJwtBearer(o =>
                    {
                        o.RequireHttpsMetadata = false;
                        o.SaveToken = true;
                        o.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = JWTSigningKey,
                            ValidateIssuer = true,
                            ValidIssuer = "PPG",
                            ValidateAudience = true,
                            ValidAudience = "PPGAud",
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.FromMinutes(5.0)
                        };
                    });


            services.AddMvc();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IFeedCodeServices, FeedCodeServices>();

            services.AddApiVersioning(o => o.ApiVersionReader = new HeaderApiVersionReader("api-version")); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
