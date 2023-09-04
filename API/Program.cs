using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.servicesRegistrations(builder.Configuration);

var app = builder.Build();

app.EndpointRegistration();

app.Run();
