using Microsoft.EntityFrameworkCore;
using BookReviewAPI.Models;
using BookReviewAPI.Interfaces;
using BookReviewAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookReviewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookReviewContext")));

builder.Services.AddScoped<IBookReviewService, BookReviewService>();

var app = builder.Build(); 

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
