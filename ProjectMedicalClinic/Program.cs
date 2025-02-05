using Microsoft.EntityFrameworkCore;
using ProjectMedicalClinic.Models;
using Microsoft.AspNetCore.Identity;
using ProjectMedicalClinic.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.AddControllersWithViews();
services.AddDbContext<MedicalClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalClinicContext")));

services.AddDbContext<AccountContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalClinicContext")));

services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AccountContext>();

services.AddRazorPages();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Medical Clinic API", Version = "v1" });
});


var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical Clinic API V1");
    });
}


app.MapRazorPages();
app.MapControllers(); 


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
