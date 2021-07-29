using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyLibrus.Controllers;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO.CreateDTO;
using MyLibrus.Interfaces.IRepositories;
using MyLibrus.Interfaces.IServices;
using MyLibrus.Middleware;
using MyLibrus.Repositories;
using MyLibrus.Services;
using MyLibrus.Tables;
using MyLibrus.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrus
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
            #region Auth
            //created new object of AuthenticationSettins (AS)
            var authenticationSettins = new AuthenticationSettins();
            //here we just take our no hard coded settins from appsettings.json and bind it to above object
            Configuration.GetSection("Authentication").Bind(authenticationSettins);

            //now we are able to inject it into our service ??
            services.AddSingleton(authenticationSettins);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(opt =>
            {
                //Czy wymagany jest protokol HTTPS, na developie ustawia sie false, na prod jest domyslnie TRUE
                // poczytac o protokolach i cerrtyfikatach
                opt.RequireHttpsMetadata = false;
                //token should be saved in server for authentication purpose
                opt.SaveToken = true;
                //parameters of validation, we need it to change if parameters from client are correct with it, what server knows
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //Issuer of token
                    ValidIssuer = authenticationSettins.JwtIssuer,
                    //Who can use this token?
                    ValidAudience = authenticationSettins.JwtIssuer,
                    //here we have our private key, based on JwtKey
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettins.JwtKey))                       
                };
            });
            #endregion
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyLibrus", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "MyAuto",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {{
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },

                    new string[]{ }
                    }
                });
            });
            #endregion
            services.AddSingleton<TrainingClass>();
            services.AddDbContext<MyLibrusDbContext>();
            services.AddScoped<StudentRepository>();
            services.AddScoped<StudentService>();
            services.AddScoped<StudentSeeder>();           
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IValidator<CreateUserDTO>, RegisterUserValidation>();
            services.AddControllers().AddFluentValidation();
            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,StudentSeeder seeder)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            seeder.Seed();
            
            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyLibrus v1"));
            }
            else
            {
                app.UseMiddleware<ErrorHandlingMiddleware>();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyLibrus v1"));
            }
            //start of request

            

            app.UseAuthentication();

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
