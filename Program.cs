var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

var app = builder.Build();
app.MapControllers();
app.Run();
