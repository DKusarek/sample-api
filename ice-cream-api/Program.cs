using FastEndpoints;
using FastEndpoints.Swagger;
using hp_api.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddSingleton<IIceCreamService, IceCreamService>();
var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(x => x.ConfigureDefaults());

app.Run();