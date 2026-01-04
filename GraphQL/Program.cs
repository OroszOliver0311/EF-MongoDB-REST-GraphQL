using graphql.server;
using graphql.server.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDbContextFactory<AdatvezDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DBadatvez"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContextFactory<AdatvezDbContext>()
    .AddQueryType<Query>()
    .AddMutationType<ProductMutation>()
    .AddProjections(); 

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();

