using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;
using TimingDemo.Api.Data;
using TimingDemo.Api.Middleware;
using TimingDemo.Api.Options;
using TimingDemo.Api.Services.Categories;
using TimingDemo.Api.Services.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

builder.Services.AddControllers().AddJsonOptions(options => 
{
    options.JsonSerializerOptions.DefaultIgnoreCondition =
                       JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddSingleton(TimeProvider.System);

// Register services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.Configure<PerformanceOptions>(
    builder.Configuration.GetSection(PerformanceOptions.SectionName));

// Register the AppDbContext with the connection string: 
var connectionString =builder.Configuration.GetConnectionString("DefaultConnection") ??
           throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
;

builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseSqlServer(connectionString);
});

//Register cors

var frontendUrl =  builder.Configuration["Cors:FrontendUrl"]
                ?? throw new InvalidOperationException("Frontend URL is not configured.");


builder.Services.AddCors(options =>
options.AddPolicy(
   "AllowFrontend",
   policy => policy
       .WithOrigins(frontendUrl)
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowCredentials()
       .WithExposedHeaders("X-Response-Time-ms")
       ));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TimingDemo API V1");

        options.EnableDeepLinking();
        options.DisplayRequestDuration();
        options.EnableFilter();
    });

    app.MapScalarApiReference();
}

app.UseRouting();


app.UseHttpsRedirection();

// register ResponseTiming Middleware:

app.UseMiddleware<ResponseTimingMiddleware>();

app.UseCors("AllowFrontend");

app.MapControllers();





app.Run();

