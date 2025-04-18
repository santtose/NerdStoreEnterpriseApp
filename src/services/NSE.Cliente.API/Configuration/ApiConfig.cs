﻿using Microsoft.EntityFrameworkCore;
using NSE.Clientes.API.Data;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Clientes.API.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClientesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });
        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseCors("Total");

            app.UseAuthConfiguration();

            app.MapControllers();
        }
    }
}
