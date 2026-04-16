using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WMSPro.Data;
using WMSPro.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// ── SQLite Database ──
// File wmspro.db sẽ được tạo tự động trong thư mục gốc của project
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=wmspro.db"));

// ── ASP.NET Core Identity ──
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Cấu hình mật khẩu - đơn giản hoá cho môi trường học tập
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    // Khoá tài khoản sau 5 lần nhập sai
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// ── Cấu hình Cookie xác thực ──
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ── Phân quyền Policy ──
builder.Services.AddAuthorization(options =>
{
    // Chỉ Admin (Quản trị viên IT)
    options.AddPolicy("ChiAdmin", p => p.RequireRole(VaiTroConst.Admin));
    // Admin và Quản lý
    options.AddPolicy("QuanLyVaAdmin", p => p.RequireRole(VaiTroConst.Admin, VaiTroConst.QuanLy));
    // Mọi người đăng nhập
    options.AddPolicy("DaDangNhap", p => p.RequireAuthenticatedUser());
});

var app = builder.Build();

// ── Tự động migrate DB và seed dữ liệu khi khởi động ──
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // Tạo / cập nhật DB tự động
    await DbSeeder.SeedAsync(scope.ServiceProvider);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // ← Phải trước UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
