using DynamicallyRole.Data;
using DynamicallyRole.Repo;
using DynamicAuthorization.Mvc.Core.Extensions;
using DynamicAuthorization.Mvc.MsSqlServerStore;
using DynamicAuthorization.Mvc.Ui;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();




builder.Services.AddDynamicAuthorization<ApplicationDbContext>(opt => opt.DefaultAdminUser = null).AddSqlServerStore(options => options.ConnectionString = connectionString)
	.AddUi(builder.Services.AddControllersWithViews());

builder.Services.AddScoped<IDbInit, DbInit>();

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.Use(async (context, next) =>
{
	await RoleSeedAsync(app);  // This will run on every request
	await next.Invoke();  // Proceed to the next middleware
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

 async Task RoleSeedAsync(WebApplication app)
{
	using (var scope = app.Services.CreateScope())
	{
		var dbRop = scope.ServiceProvider.GetRequiredService<IDbInit>();
		await dbRop.RoleSeed();
	}
}