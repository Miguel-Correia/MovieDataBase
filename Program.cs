using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieDataBase.Data;
using Minio;
using MovieDataBase.Services;
using System.Net.Http.Headers;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MovieDataBaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."))
        .UseSnakeCaseNamingConvention());


// Registrar typed HttpClient para SupabaseStorageService (configura base address e headers)
builder.Services.AddHttpClient<SupabaseStorageService>((sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var url = configuration["Supabase:Url"] ?? throw new InvalidOperationException("Supabase:Url não configurado");
    var key = configuration["Supabase:Key"] ?? throw new InvalidOperationException("Supabase:Key não configurado");
    client.BaseAddress = new Uri(url.TrimEnd('/'));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
    client.DefaultRequestHeaders.Add("apikey", key);
});

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
