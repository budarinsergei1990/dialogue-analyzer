using DialogueAnalyzer.Application.Interfaces;
using DialogueAnalyzer.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IHealthCheckService, HealthCheckService>();

var app = builder.Build();

app.MapGet("/healthy", (IHealthCheckService service) => service.GetHealthStatus());

app.Run();


public partial class Program { }