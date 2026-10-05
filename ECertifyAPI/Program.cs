using ECertifyAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace ECertifyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Service Confiruration
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ECertifyContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"),
                    providerOptions => providerOptions.EnableRetryOnFailure()); // hwlpful in first time db connection
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            #endregion Service Confiruration End

            #region Configurating Middleware
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion Configurating Middleware End
        }
    }
}
