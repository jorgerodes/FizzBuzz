using Asp.Versioning;
using Asp.Versioning.Builder;
using FizzBuzz.Api.FizzBuzz;
using FizzBuzz.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication(); //mediaTr, logging, FizzBuzzService, etc.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

ApiVersionSet apiVersion = app.NewApiVersionSet().HasApiVersion(new ApiVersion(1))
    .ReportApiVersions().Build();

var routeGroupBuilder = app.MapGroup("api/v{version:apiVersion}").WithApiVersionSet(apiVersion);

routeGroupBuilder.MapFizzBuzzEndpoints();

app.Run();
