using Models_DB_and_Request.ModelsRequest.Models;
using WebAPI.Services.ServicesExternalMenu;
using WebAPI.Services.ServicesExternalMenu.IServices;
using WebAPI.Services.ServicesToken;
using WebAPI.Services.ServicesToken.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---- Настройка iiko ----
builder.Services.Configure<IikoApiOptions>(
    builder.Configuration.GetSection("IikoApi"));
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddScoped<IExternalMenuService, ExternalMenuService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("https://localhost:7144") // ← ваш порт Blazor
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazor");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();