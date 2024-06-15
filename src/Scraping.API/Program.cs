using Microsoft.EntityFrameworkCore;
using Scraping.Application.Interfaces;
using Scraping.Application.Mappings;
using Scraping.Application.Services;
using Scraping.Domain.Interfaces;
using Scraping.Infrastructure.Data;
using Scraping.Infrastructure.Repositories;
using Scraping.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IFoodScrapper, FoodScrapper>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://scraping-front-six.vercel.app", "http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
