using BudgetTracker.Data;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var defaultConnectionString = builder.Configuration.GetConnectionString("BudgetTrackerContext");
var identityConnectionString = builder.Configuration.GetConnectionString("AppDbIdentityContext") 
    ?? throw new InvalidOperationException("Connection string 'AppDbIdentityContext' not found.");

// Add services to the container.
builder.Services.AddSingleton<EntityConfigFactory>();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(defaultConnectionString)
);
builder.Services.AddDbContext<AppDbIdentityContext>(options =>
    options.UseSqlServer(identityConnectionString)
); 
builder.Services.AddDefaultIdentity<AppUser>(
    options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
    }
).AddEntityFrameworkStores<AppDbIdentityContext>();
builder.Services.AddControllersWithViews();


// Configure the HTTP request pipeline.
var app = builder.Build();
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

app.MapRazorPages();
app.MapDefaultControllerRoute()
    .RequireAuthorization();

app.Run();
