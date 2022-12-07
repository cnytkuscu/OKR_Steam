
using Microsoft.EntityFrameworkCore;
using OKR_Steam.Business.BS;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.Middlewares;
using RequestResponseLogger.DataAccess;
using RequestResponseLogger.Interfaces;
using RequestResponseLogger.Middleware;
using RequestResponseLogger.Models;
using Serilog;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration().CreateLogger();

        // Add services to the container.

        builder.Services.AddControllers();

        //DbContext Here
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

        builder.Services.AddScoped<IUserBusiness, UserBusiness>();
        builder.Services.AddScoped<IUserDataAccess, UserDataAccess>();

        builder.Services.AddScoped<IInventoryBusiness, InventoryBusiness>();
        builder.Services.AddScoped<IInventoryDataAccess, InventoryDataAccess>();

        builder.Services.AddScoped<IItemBusiness, ItemBusiness>();
        builder.Services.AddScoped<IItemDataAccess, ItemDataAccess>();

        builder.Services.AddScoped<IServiceLogDataAccess, ServiceLogDataAccess>();
        builder.Services.AddSingleton<IRequestResponseLogger, RequestResponseLogger.Models.RequestResponseLogger>();
        builder.Services.AddScoped<IRequestResponseLogModelCreator, RequestResponseLogModelCreator>();



       
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        var app = builder.Build();
        
        //hata olursa bu sayfaya gidecek.
        app.UseExceptionHandler("/Error");

        // Configure the HTTP request pipeline.

        app.UseSwagger();
        app.UseSwaggerUI();

        //Harici Middleware
        app.RequestResponseLogger();

        //Dahili Middleware
        app.UseMiddleware<ErrorHandlerMiddleware>();       


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}