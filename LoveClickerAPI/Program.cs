using System.Reflection;
using Microsoft.EntityFrameworkCore;
using LoveClickerAPI.Business.Interfaces;
using LoveClickerAPI.Business.Services;
using LoveClickerAPI.Persistence.Models;
using LoveClickerAPI.Persistence.Repositories;
using LoveClickerAPI.Persistence.Interfaces;
using LoveClickerAPI.Business.Helpers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddDbContext<LoveClickerAPIContext>(options =>
    options.UseSqlite("Data Source=Persistence/Database/LoveClicker_dev.db"));

builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();