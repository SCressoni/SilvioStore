using System.Net;
using Microsoft.OpenApi.Models;
using SilvioStore.Api;
using SilvioStore.Domain.StoreContext.Handlers;
using SilvioStore.Domain.StoreContext.Repositories;
using SilvioStore.Domain.StoreContext.Services;
using SilvioStore.Domain.StoreContext.ValueObjects;
using SilvioStore.Infra.StoreContext.DataContexts;
using SilvioStore.Infra.StoreContext.Repositories;
using Elmah.Io.AspNetCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

builder.Configuration.
    
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<SilvioDataContext, SilvioDataContext>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IEmailService, IEmailService>();
builder.Services.AddTransient<CustomerHandler, CustomerHandler>();

builder.Services.AddResponseCompression();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Silvio Store", Version = "V1"});
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseResponseCompression();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/docs/v1/swagger.json", "Silvio Store V1");
});

app.UseElmahIo("8e2697f8a2844850a046a99b99c84316", new Guid("e234228a-accf-442e-9460-8fabd75dbf46"));

app.Run();
