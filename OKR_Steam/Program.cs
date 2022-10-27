using Microsoft.EntityFrameworkCore;
using OKR_Steam.Business.BS;
using OKR_Steam.Business.IBS;
using OKR_Steam.Controllers.C;
using OKR_Steam.Controllers.IC;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.DataAccess.IDA;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//DbContext Here
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<ISteamBusiness, SteamBusiness>();
builder.Services.AddScoped<ISteamDataAccess, SteamDataAccess>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
