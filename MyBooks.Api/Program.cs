using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyBooks.Api.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
                      policy =>
                      {
                          // Permite requisições da origem do seu app Angular
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();

#region API Versioning
builder.Services.AddApiVersioning(options =>
{
    
    options.ReportApiVersions = true;    
    options.AssumeDefaultVersionWhenUnspecified = true;    
    options.DefaultApiVersion = new ApiVersion(1, 0);
}).AddApiExplorer(options =>
{    
    options.GroupNameFormat = "'v'VVV";    
    options.SubstituteApiVersionInUrl = true;
});
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    // Adiciona a funcionalidade de autoriza��o no Swagger (�til para o futuro)
    options.OperationFilter<SwaggerDefaultValues>();
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adiciona os registros da camada de Aplica��o
builder.Services.AddApplicationServices();

// Adiciona os registros da camada de Infraestrutura
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("_myAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
