using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SchoolTaskApi.Models;

namespace SchoolTaskApi
{
    public class Startup
    {
        string MyAllowSpecificOrigins = "m";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<SchoolContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Connection")));

            //ApplicationUser
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<SchoolContext>().AddDefaultTokenProviders();

            /* services.AddAuthentication(option =>
             {
                 option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticatScheme;
                 option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
             })
             	.AddJwtBearer(options=>{
                     Options.SaveToken = true;
                     Options.RequireHttpsMetaData = false;
                     Options.TokenValidationParameters = new TokenValidationParameters(){
                     ValidateIssuer = true;
                     ValidateAudience = true;
                     ValideAudience = Configuration[“Jwt:ValidAudience”]
                     ValideIssuer = Configuration[“Jwt:ValidIssuer”]
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[“Jwt:S”]))
                     }
                     })

              */

            services.AddSwaggerDocument();

            services.AddCors(options => {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            //services.AddIdenity<ApplicationUser, IdeneityRole>().AddEntityFrameworkStores(ApplicationDbContext).AddDefaultTokenProviders();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseOpenApi();
        	app.UseSwaggerUi3();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
