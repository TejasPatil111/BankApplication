using System.Text;
using AutoMapper;
using Bank.API.Middleware;
using Bank.API.Validations;
using Bank.Application.Features.Customer.Command;
using Bank.Application.Features.Transfers.Handlers;
using Bank.Application.Profiles;
using Bank.Infrastructure;
using Bank.Infrastructure.DependancyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;


namespace Bank.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>

            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,   
                    ValidateLifetime = true,    
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                };
            });



            


                // Add services to the container.
                builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateTransferHandler).Assembly);
            });
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //context service registraion
            builder.Services.AddDbContext<BankDbContext>(options =>
            
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddInfrastructureServices(builder.Configuration);



            //  Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    policy =>
                    {
                        policy.AllowAnyOrigin() // Angular dev server
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });

            var app = builder.Build();
            //app.MapGet("/", () => Results.Redirect("/swagger"));

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank API V1");
                    c.RoutePrefix = string.Empty; // Swagger at root (http://localhost:7138/)
                });
            }

            app.UseCors("AllowAngularApp");
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
                

            app.Run();
        }
    }
}
