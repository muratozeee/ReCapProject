
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // it means new and just one reference for that one and it is provide us very fast no need to memory every each one...


            //builder.Services.AddSingleton<IBrandService, BrandManager>();
            //builder.Services.AddSingleton<IBrandDal, EfBrandDal>();

            //builder.Services.AddSingleton<ICarService, CarManager>();
            //builder.Services.AddSingleton<ICarDal, EfCarDal>();

            //builder.Services.AddSingleton<IColorService, ColorManager>();
            //builder.Services.AddSingleton<IColorDal, EfColorDal>();

            //builder.Services.AddSingleton<ICustomerService, CustomerManager>();
            //builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

            //builder.Services.AddSingleton<IRentalService, RentalManager>();
            //builder.Services.AddSingleton<IRentalDal, EfRentalDal>();

            //builder.Services.AddSingleton<IUserService ,UserManager>();
            //builder.Services.AddSingleton<IUserDal, EfUserDal>();

           var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });







            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Autofac

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(options =>
            {
                options.RegisterModule(new AutofacBusinessModule());
            });


            //
            var app = builder.Build();


            // Configure the HTTP request pipeline.




            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

           

            //it is middlewave
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}