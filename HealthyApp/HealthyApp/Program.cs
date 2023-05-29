using HealthyApp.Areas.Identity;
using HealthyApp.Extensions;
using HealthyApp.Infra;
using HealthyApp.Services;
using HealthyApp.Services.Interfaces;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped(sp =>
        new HttpClient
        {
            BaseAddress = new Uri(builder.Configuration.GetValue<string>("BackendUri"))
        });

builder.Services.AddTransient<IHealthyUserService, HealthyApp.Services.HealthyUserService>();
builder.Services.AddTransient<IGoalService, HealthyApp.Services.GoalService>();
builder.Services.AddTransient<IGoalProgressService, HealthyApp.Services.GoalProgressService>();
builder.Services.AddTransient<IAdvisorService, HealthyApp.Services.AdvisorService>();

builder.Services.AddMapperConfig();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

builder.Services.AddHttpClient();

//builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	//app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
