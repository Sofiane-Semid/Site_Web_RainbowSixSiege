using Tp2ProgWeb.Models;
using Microsoft.AspNetCore.Builder;
using System;
var builder = WebApplication.CreateBuilder(args); // Crée une web app avec les paramètres envoyés
builder.Services.AddControllersWithViews(); // Permet MVC
builder.Services.AddRazorPages(); // Permet utilisation de Razor
builder.Services.AddSingleton<Database>(); // Permet l'utilisation du Singleton

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = context => context.Context.Response.Headers.Add("Cache-Control", "no-cache")
    });
}
else
{
    app.UseStaticFiles();
}
app.UseSession();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}",
        defaults: new { controller = "Home", action = "Index" });
});

app.MapRazorPages();
app.Run();