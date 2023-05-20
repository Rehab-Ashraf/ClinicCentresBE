using Autofac;
using ClinicCenters.Web.Api.Bootstrapper;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Data.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ClinicCenters.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("ClinicCentresDbConnection");

            services.AddDbContext<ClinicCentresDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
            services.AddControllers(options => options.Filters.Add(new AuthorizeFilter()));
            services.AddIdentity<User, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["IdentitySettings:Issuer"],
                        ValidAudience = Configuration["IdentitySettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["IdentitySettings:SecurityKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireSuperAdminRole",
                 policy => policy.RequireRole("SuperAdmin"));
                options.AddPolicy("RequireAdminRole",
                 policy => policy.RequireRole("Admin"));
                options.AddPolicy("RequireUserRole",
                 policy => policy.RequireRole("User"));

                options.AddPolicy("AddBranch", policy
                    => policy.RequireClaim(claimType: "Granted", "AddBranch"));
                options.AddPolicy("DeleteBranch", policy
                    => policy.RequireClaim(claimType: "Granted", "DeleteAppointment"));

                options.AddPolicy("AddCategory", policy
                    => policy.RequireClaim(claimType: "Granted", "AddCategory"));
                options.AddPolicy("DeleteCategory", policy
                    => policy.RequireClaim(claimType: "Granted", "DeleteCategory"));

                options.AddPolicy("AddProduct", policy
                    => policy.RequireClaim(claimType: "Granted", "AddProduct"));
                
                options.AddPolicy("AllCases", policy
                    => policy.RequireClaim(claimType: "Granted", "AllCases"));
                options.AddPolicy("DeleteCase", policy
                    => policy.RequireClaim(claimType: "Granted", "DeleteCase"));

                options.AddPolicy("AddAppointment", policy
                    => policy.RequireClaim(claimType: "Granted", "AddAppointment"));
                options.AddPolicy("DeleteAppointment", policy
                    => policy.RequireClaim(claimType: "Granted", "DeleteAppointment"));

                options.AddPolicy("GetImage", policy
                    => policy.RequireClaim(claimType: "Granted", "GetImage"));
                options.AddPolicy("DeleteImage", policy
                    => policy.RequireClaim(claimType: "Granted", "DeleteImage"));
                options.AddPolicy("AddImage", policy
                    => policy.RequireClaim(claimType: "Granted", "AddImage"));

            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                    builder =>
                                    {
                                        builder.WithOrigins("*");
                                        builder.AllowAnyOrigin();
                                        builder.AllowAnyHeader();
                                        builder.AllowAnyMethod();

                                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clinic Centers",
                    Description = "Clinic Centers - APIs documentation ",
                    TermsOfService = null,
                    Contact = new OpenApiContact
                    {
                        Name = "Clinic Centers Team.",
                        Email = "rehabashraf063@gmail.com",
                        Url = new Uri("http://c-systems.com")
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
              {
                  {
                        new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                          Array.Empty<string>()
                  }
              });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicCenters.Web.Api v1"));

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyResolver(_env));
        }
    }
}
