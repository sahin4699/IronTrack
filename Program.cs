using Microsoft.EntityFrameworkCore;
using WorkoutTrackerApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=workout.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS İzni (Render ve Mobil için)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// SQLite veritabanı ve tabloları otomatik oluştur
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseCors("AllowAll");

app.UseDefaultFiles();
app.UseStaticFiles();

// Swagger (opsiyonel geliştirici ekranı)
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();