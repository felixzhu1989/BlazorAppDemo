using BlazorAppCodingDroplets;
using BlazorAppCodingDroplets.Authentication;
using BlazorAppCodingDroplets.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//身份验证用的SessionStorage
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationSateProvider>();
builder.Services.AddSingleton<UserAccountServer>();

ConfigureServiceCollection(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


static void ConfigureServiceCollection(IServiceCollection services)
{
    //services.AddSingleton<ContactService>();
    //services.AddTransient<ContactService>();
    //services.AddSingleton<IContactService, ContactService>();
    services.AddSingleton<IContactService, ContactServiceNew>();
    services.AddDbContext<TestDbContext>(options =>
    {
        options.UseSqlite("Data Source=test.db");
    });
    services.AddScoped<MemberServices>();
}