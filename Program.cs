using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using singinAndUp.Areas.Identity.Data;
using singinAndUp.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("singinAndUpDBContextConnection") ?? throw new InvalidOperationException("Connection string 'singinAndUpDBContextConnection' not found.");

builder.Services.AddDbContext<singinAndUpDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<appUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<singinAndUpDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
});







builder.Services.AddRazorPages();







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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");








app.MapRazorPages();




app.Run();
