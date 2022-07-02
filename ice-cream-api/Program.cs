using FastEndpoints;
using FastEndpoints.Swagger;
using hp_api.Contracts.Responces;
using hp_api.Services;
using hp_api.Validators;

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddSingleton<IIceCreamService, IceCreamService>();

var app = builder.Build();
app.UseMiddleware<ValidationMiddleware>();
app.UseAuthorization();
app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(y => y.ErrorMessage).ToList()
        };
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(x => x.ConfigureDefaults());

app.Run();