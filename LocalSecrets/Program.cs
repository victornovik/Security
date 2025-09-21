using LocalSecrets.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// Read from .NET Secret Manager
var connString = builder.Configuration.GetConnectionString("WeatherStoreContext");

builder.Services.AddSingleton<TestConfiguration>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var cfg = app.Services.GetRequiredService<TestConfiguration>();
var res1 = cfg.ReadSettings();

var res2 = cfg.BindCfgToClass();
// Another option
// builder.Services.Configure<PositionOptions>(builder.Configuration.GetSection(PositionOptions.OptName));


app.Run();