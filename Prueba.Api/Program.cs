using FluentValidation.AspNetCore;
using InsttanttFlujos.Infrastructure.Filters;
using Microsoft.EntityFrameworkCore;
using PostgresSql.Data;
using Prueba.Infrastructure.Extensions;
using Prueba.Intrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);
var configutarion = builder.Configuration;

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

// Add Cors
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder =>
    { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("WWW-Authenticate"); })
);

//   Para la configuración del Swagger
builder.AddServicesSwaggerGen();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(FilterOfExcepcion));
    options.Filters.Add<GlobalExceptionFilter>();
});

// Cadena de Conexión para Sql Server
//builder.Services.AddDbContext<InsttanttFlujosContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);

// Cadena de Conexión para PostgresSQL
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<CompanyRauloswaldogiraldoContext>(options =>
    options.UseNpgsql(connectionString)
);

// Dependencias propias - (Inyeccion de dependencias)
builder.AddServices();

// Validaciones y Filtros
builder.Services.AddMvc(options => { }
).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

var app = builder.Build();

// Configure the HTTP request pipeline.  IWebHostEnvironment
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba.Api v1"));
    app.UseCors();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
