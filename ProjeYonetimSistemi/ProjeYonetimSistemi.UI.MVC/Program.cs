#region NAMESPACES
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjeYonetimSistemi.UI.MVC.Context;
using ProjeYonetimSistemi.UI.MVC.Middleware;
using AutoMapper;
using ProjeYonetimSistemi.UI.MVC;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Email ayarlar�n� yap�land�rmak i�in konfig�rasyonu okuyun
var emailConfig = builder.Configuration.GetSection("EmailSettings").Get<EmailSettings>();

// Veritaban� ba�lant� dizesini ayarlay�n
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Identity ve Entity Framework konfig�rasyonlar�
builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager<SignInManager<IdentityUser>>();

// AutoMapper konfigurasyonunu ekleyin
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

// Cookie bazl� kimlik do�rulama ayarlar�
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Kullan�c� giri� yapmadan �nce otomatik olarak y�nlendirilecek sayfa
    });

// EmailSender servisini DI konteyner�na ekleyin
builder.Services.AddSingleton(new EmailSender(
    emailConfig.SmtpServer,
    emailConfig.SmtpPort,
    emailConfig.SmtpUser,
    emailConfig.SmtpPass
));

// MVC i�in gerekli servisleri ekleyin
builder.Services.AddControllersWithViews();

// Authorization politikalar�n� ekleme
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy =>
    {
        policy.RequireRole("admin");
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<CustomAuthorizeMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// EmailSettings s�n�f�n� tan�mlay�n
public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; }
    public string SmtpPass { get; set; }
}
