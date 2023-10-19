using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace CoAutoAPI
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

            builder.Services.AddTransient<IAluguelService, AluguelService>();
            builder.Services.AddTransient<IBancoService, BancoService>();
            builder.Services.AddTransient<IDisponibilidadeService, DisponibilidadeService>();
            builder.Services.AddTransient<IPagamentoService, PagamentoService>();
            builder.Services.AddTransient<IMarcaService, MarcaService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<CoAutoContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("CoAutoDatabase")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}