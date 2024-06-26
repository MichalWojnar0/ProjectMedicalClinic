using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


/*app.MapGet("/", (HttpContext context) => {
    string html = @"<html>
                    <body>
                        <h1>Hello World!</h1>
                        <br/>
                        Welcome to this
                    </body>
                    </html>";
    WriteHtml(context, html);
});
*/
app.Run();

/*void WriteHtml(HttpContext context, string html)
{
    context.Response.ContentType = MediaTypeNames.Text.Html;
    context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
    context.Response.WriteAsync(html);
}
*/