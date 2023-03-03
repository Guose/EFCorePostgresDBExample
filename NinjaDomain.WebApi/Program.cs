using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Configuration;
using Microsoft.EntityFrameworkCore;
using NinjaDomain.Data.Data;

namespace NinjaDomain.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<NinjaDbContext>(opt =>
                                opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

            builder.Services.AddPooledDbContextFactory<NinjaDbContext>(cfg => cfg.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

            builder.Services.AddLinqToDBContext<NinjaContext>((provider, options) =>
            {
                options.UsePostgreSQL(builder.Configuration.GetConnectionString("PostgresConnection")).UseDefaultLogging(provider);
            });

            var app = builder.Build();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (IServiceScope scope = app.Services.CreateScope())
            {
                var dataConnection = scope.ServiceProvider.GetService<NinjaContext>();

                //dataConnection.CreateTable<Command>();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}