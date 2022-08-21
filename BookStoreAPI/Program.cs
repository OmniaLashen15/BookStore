using BookStoreAPI.Extensions;
using BookStoreAPI.Repository;
using BookStoreData;
using BookStoreDomain;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
///builder.Services.AddTransient<ExceptionHandlerMiddleware>();

builder.Services.AddControllers()
    .AddJsonOptions(opt=>opt.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreConnection"))
    .EnableSensitiveDataLogging()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddScoped<IRepository<Author>, AuthorRepository>();
builder.Services.AddScoped<IRepository<Book>, BookRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
///app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();
app.ConfigureExceptionHandler();
app.Run();
