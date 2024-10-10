using DynamicallyRole.Data;
using DynamicallyRole.Repo;
using DynamicAuthorization.Mvc.Core.Extensions;
using DynamicAuthorization.Mvc.MsSqlServerStore;
using DynamicAuthorization.Mvc.Ui;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));


builder.Services.ConfigureApplicationCookie(options =>
    options.AccessDeniedPath = new PathString("/Account/NoAccess"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
	options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddDynamicAuthorization<ApplicationDbContext>(options =>
	options.DefaultAdminUser = "UserName")
	.AddSqlServerStore(options => options.ConnectionString = connectionString)
	.AddUi(builder.Services.AddControllersWithViews());

/*builder.Services.AddScoped<IDbInit, DbInit>();*/

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
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

/*async Task RoleSeedAsync(WebApplication app)
{
	using (var scope = app.Services.CreateScope())
	{
		var dbRop = scope.ServiceProvider.GetRequiredService<IDbInit>();
		await dbRop.RoleSeed();
	}
}
*/