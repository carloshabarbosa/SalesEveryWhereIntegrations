using Autofac.Extensions.DependencyInjection;
using Infra.IoC;
using Infra.IoC.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterEventBus(builder.Configuration);

builder.Services.AddConfigurations();

builder.Services.AddDatabaseConfig(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var app = builder.Build();

app.Services.ConfigureServiceBus();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
