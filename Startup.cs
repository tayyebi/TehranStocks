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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TehranStocks.Context;
using TehranStocks.Database;
using TehranStocks.Middleware;

namespace TehranStocks
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Convert.ToBoolean(Configuration["UsePersistentDatabase"]))
            {
                services.AddDbContext<AppDbContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("TehranStocks")));
            }
            else
            {
                services.AddDbContext<AppDbContext>(opt =>
                    opt.UseInMemoryDatabase("TehranStocks"));
            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = Configuration["Customization:AppName"] + " API",
                    Description = Configuration["Customization:AppDescription"],
                    TermsOfService = new Uri("https://github.com/tayyebi/Tashilat/blob/master/TermsOfService.md"),
                    Contact = new OpenApiContact
                    {
                        Name = "MohammadReza Tayyebi",
                        Email = "smile@tyyi.net",
                        Url = new Uri("http://tyyi.net"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://github.com/tayyebi/Tashilat/blob/master/LICENCE"),
                    }
                });
            });

            services.AddTransient<AccessMiddleware>();
            services.AddScoped<UnitOfWork>();
            services.AddRepositories(Configuration);
            services.AddServices();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Configuration["Customization:AppName"] + " API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<AccessMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
