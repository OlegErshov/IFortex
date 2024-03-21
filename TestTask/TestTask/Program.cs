using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestTask;
using TestTask.Data;
using TestTask.Repositories.Implementations;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddScoped<IOrderRepository,OrderRepository>()
    .AddScoped<IUserRepositoty,UserRepository>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IUserService, UserService>();

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
