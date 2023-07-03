using Microsoft.AspNetCore.Identity;
using PriceParser;
using PriceParser.Application;
using PriceParser.Application.Interfaces;
using PriceParser.Application.Mappings;
using PriceParser.Data.EF;
using PriceParser.Data.EF.Identity;
using PriceParser.Parser;
using PriceParser.Parser.Markets;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbIdentit(builder.Configuration.GetConnectionString("DbIdentity"))
                .AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
                    config.Password.RequiredLength = 6;
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Account/Login";
});

builder.Services.AddPriceParserDb(builder.Configuration.GetConnectionString("PriceParser"));

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IRequestResultRepository).Assembly));
});

builder.Services.AddControllersWithViews();
builder.Services.AddApplication();
builder.Services.AddParser();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
