using CompanyEmployees.Extensions;
using Contracts;
using Microsoft.Extensions.Logging;
using NLog;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Connect database
builder.Services.ConfigureNpgsqlContext(builder.Configuration);

// Add services to the container.
// Register dependent services here: (ConfigureServices)
builder.Services.ConfigureRepositoryManager();

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader= true;
    config.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters()
  .AddCustomCSVFormatter(); // custom formatter (CsvOutputFormatter)

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// !!!The code below must have been added to the constructor of Startup class
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

var app = builder.Build();
// Register middleware here: (Configure)  //(don't forget that order matters!)

app.UseMiddleware(typeof(ExceptionHandlingMiddleware)); // exception handling middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// It enables using static fields for the request. If a path to the static files directory isn't set, a "wwwroot" folder in our project will be used by default
app.UseStaticFiles();

app.UseCors("CorsPolicy");

// It provides proxy headers to the current request. This helps during application deployment
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
