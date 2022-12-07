using Microsoft.EntityFrameworkCore;
using OKR_Steam.Business.BS;
using OKR_Steam.Business.IBS;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Middlewares;
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




        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        var app = builder.Build();
        
        //hata olursa bu sayfaya gidecek.
        app.UseExceptionHandler("/Error");

        // Configure the HTTP request pipeline.

        app.UseSwagger();
        app.UseSwaggerUI();

        //app.ErrorHandlerMiddlewareConnector();
        app.UseMiddleware<ErrorHandlerMiddleware>();
        //app.UseMiddleware<RequestCheckMiddleware>();


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}