using AutoMapper;
using ISMSPortal.Configuration;
using ISMSPortal.Data;
using ISMSPortal.Helpers;
using ISMSPortal.Repositories.Implementations;
using ISMSPortal.Repositories.Interfaces;
using ISMSPortal.Services.Implementations;
using ISMSPortal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region MVC

builder.Services.AddControllersWithViews();

#endregion

#region Database

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region Configuration

builder.Services.Configure<ApplicationSettings>(
    builder.Configuration.GetSection("ApplicationSettings"));

#endregion

#region Session

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(cfg =>
{
    // Leave empty unless you have an AutoMapper license.
}, typeof(Program));

#endregion

#region Repositories

builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();

builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();

builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();

builder.Services.AddScoped<ISecurityAlertRepository, SecurityAlertRepository>();

builder.Services.AddScoped<IAwarenessSessionRepository, AwarenessSessionRepository>();

builder.Services.AddScoped<IAwarenessProgressRepository, AwarenessProgressRepository>();

#endregion

#region Services

builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();

builder.Services.AddScoped<IDocumentService, DocumentService>();

builder.Services.AddScoped<IPolicyService, PolicyService>();

builder.Services.AddScoped<ISecurityAlertService, SecurityAlertService>();

builder.Services.AddScoped<IAwarenessSessionService, AwarenessSessionService>();

builder.Services.AddScoped<IAwarenessProgressService, AwarenessProgressService>();

builder.Services.AddScoped<IFileStorageService, FileStorageService>();

#endregion

var app = builder.Build();

#region Middleware

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

#endregion

#region Routing

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

app.Run();