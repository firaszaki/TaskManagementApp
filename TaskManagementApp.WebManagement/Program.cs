using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using TaskManagementApp.Domain;
using TaskManagementApp.WebManagement.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
          opt =>
          {
              opt.CommandTimeout(300);
              opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);

          });
    options.EnableSensitiveDataLogging();
});

// Add services to the container.
builder.Services.AddMudServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
