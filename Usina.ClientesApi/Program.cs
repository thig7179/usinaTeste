using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usina.ClientesApi.Config;
using Usina.ClientesApi.Models.Context;
using Usina.ClientesApi.Repositories;

namespace Usina.ClientesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add the configuration for MySQL
            builder.Configuration.AddJsonFile("appsettings.json");
            var configuration = builder.Configuration.Get<Configuration>();

            // Configure the DbContext with MySQL connection
            builder.Services.AddDbContext<MySqlContext>(options =>
            {
                options.UseMySql(configuration.MySqlConnection, ServerVersion.AutoDetect(configuration.MySqlConnection));
            });

            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IClientesRepository, ClienteRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        
    }
    public class Configuration
    {
        public string MySqlConnection { get; set; }
    }
}