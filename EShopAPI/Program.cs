
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EShopDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("EShopDB"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program));

            #region service injection
            builder.Services.AddScoped<ICustomerServiceAsync, CustomerServicesAsync>();
            #endregion
            #region repository injection
            builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
            #endregion
            #region
            builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();
            #endregion
            #region
            builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
            #endregion








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
}
