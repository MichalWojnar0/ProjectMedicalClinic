using Microsoft.EntityFrameworkCore;
using ProjectMedicalClinic.Models;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ProjectMedicalClinic.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MedicalClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalClinicContext")));

builder.Services.AddDbContext<AccountContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalClinicContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

