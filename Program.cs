using Hangfire.MemoryStorage;
using Hangfire;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie API", Version = "v1" });
});
builder.Services.AddControllers();
builder.Services.AddHangfire(options => options.UseMemoryStorage());
builder.Services.AddHangfireServer();
JobStorage.Current = new MemoryStorage();




var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1");
});
app.UseHangfireDashboard();
app.UseAuthorization();

app.MapControllers();

app.Run();
