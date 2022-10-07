using BlazorAppCodingDroplets;
using BlazorAppCodingDroplets.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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