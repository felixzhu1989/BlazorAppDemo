using BlazingPizza.Data;
using BlazingPizza.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//AddHttpClient �������Ӧ�÷��� HTTP ��� Ӧ��ʹ�� HttpClient ��ȡ�����ؼ���Ʒ�� JSON��
builder.Services.AddHttpClient();
//ע���µ� PizzaStoreContext�����ṩ SQLite ���ݿ���ļ�����
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");
//����µ� OrderState ����
builder.Services.AddScoped<OrderState>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//Blazor ·��
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();