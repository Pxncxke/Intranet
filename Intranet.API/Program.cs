using Intranet.Application;
using Intranet.Infrastructure.Infrastructure;
using Intranet.Persistence;
using Intranet.API.Middleware;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.WebHost.UseNLog();
// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("IntranetUI", builder =>
    builder.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .WithExposedHeaders("*"));
});

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

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("IntranetUI");

app.UseAuthorization();

app.MapControllers();

app.Run();
