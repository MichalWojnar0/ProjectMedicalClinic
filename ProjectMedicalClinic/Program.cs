using Microsoft.EntityFrameworkCore;
using ProjectMedicalClinic.Models;
using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext before building the app.
builder.Services.AddDbContext<MedicalClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalClinicContext")));

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/* Uncomment this part if you need a simple endpoint for testing
app.MapGet("/", (HttpContext context) => {
    string html = @"<html>
                    <body>
                        <h1>Hello World!</h1>
                        <br/>
                        Welcome to this
                    </body>
                    </html>";
    WriteHtml(context, html);
});

void WriteHtml(HttpContext context, string html)
{
    context.Response.ContentType = MediaTypeNames.Text.Html;
    context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
    context.Response.WriteAsync(html);
}
*/
