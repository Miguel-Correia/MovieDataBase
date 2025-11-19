using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieDataBase.Data;
using Minio;
using MovieDataBase.Services;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MovieDataBaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."))
        .UseSnakeCaseNamingConvention());

// Configurar MinIO Client
builder.Services.AddMinio(configureClient => configureClient
    .WithEndpoint(builder.Configuration["MinIO:Endpoint"] ?? "localhost:9002")
    .WithCredentials(
        builder.Configuration["MinIO:AccessKey"] ?? "minioadmin",
        builder.Configuration["MinIO:SecretKey"] ?? "minioadmin123")
    .WithSSL(false)); // true se usar HTTPS



// Registrar o serviço de storage
// Para MinIO (desenvolvimento):
builder.Services.AddScoped<IStorageService, MinioStorageService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
