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

// Email ayarlarýný yapýlandýrmak için konfigürasyonu okuyun
var emailConfig = builder.Configuration.GetSection("EmailSettings").Get<EmailSettings>();

// Veritabaný baðlantý dizesini ayarlayýn
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Identity ve Entity Framework konfigürasyonlarý
builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager<SignInManager<IdentityUser>>();

// AutoMapper konfigurasyonunu ekleyin
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

// Cookie bazlý kimlik doðrulama ayarlarý
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Kullanýcý giriþ yapmadan önce otomatik olarak yönlendirilecek sayfa
    });

// EmailSender servisini DI konteynerýna ekleyin
builder.Services.AddSingleton(new EmailSender(
    emailConfig.SmtpServer,
    emailConfig.SmtpPort,
    emailConfig.SmtpUser,
    emailConfig.SmtpPass
));

// MVC için gerekli servisleri ekleyin
builder.Services.AddControllersWithViews();

// Authorization politikalarýný ekleme
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

// EmailSettings sýnýfýný tanýmlayýn
public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; }
    public string SmtpPass { get; set; }
}
