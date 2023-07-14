using Hangfire.MemoryStorage;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHangfire(options => options.UseMemoryStorage());
builder.Services.AddHangfireServer();
JobStorage.Current = new MemoryStorage();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseHangfireDashboard();
app.UseAuthorization();

app.MapControllers();

app.Run();
