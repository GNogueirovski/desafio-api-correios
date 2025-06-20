using System.Text.Json;
using DesafioCorreiosApi.Data;
using DesafioCorreiosApi.Services;
using DesafioCorreiosApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// adding bd connection
var connectionString = builder.Configuration.GetConnectionString("CorreiosConnection");
builder.Services.AddDbContext<CorreiosContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// refit configuration
var refitSettings = new RefitSettings()
{
    ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    })
};

// adding refit client
builder.Services
    .AddRefitClient<IViaCepIntegracao>(refitSettings)
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://viacep.com.br"));



// adding automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// adding services
builder.Services.AddScoped<IClienteService,ClienteService>();
builder.Services.AddScoped<IViaCep, EnderecoService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
