using CompanyEmployees.Extensions;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Connect database
builder.Services.ConfigureNpgsqlContext(builder.Configuration);

// Add services to the container.
// Register dependent services here: (ConfigureServices)
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

// !!!The code below must have been added to the constructor of Startup class
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

var app = builder.Build();
// Register middleware here: (Configure)  //(don't forget that order matters!)
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
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
