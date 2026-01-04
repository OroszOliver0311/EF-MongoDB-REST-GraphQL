using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using webapi.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 


builder.Services.AddSingleton<IProductRepository, ProductRepository>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options=>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = "xy";

});

app.UseAuthorization();
app.MapControllers();

app.Run();
