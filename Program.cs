using blazorTowerDefense.Components;
using blazorTowerDefense.Components.Pages;
using blazorTowerDefense.Services;
using blazorTowerDefense.Singletons;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options =>
        {
            options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromSeconds(1);
        });

// custom services/singletons
builder.Services.AddScoped<GameClientService>();
builder.Services.AddSingleton<GameServerSingleton>();

// -------------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
