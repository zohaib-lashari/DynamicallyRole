
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DynamicallyRole.Repo
{
	public class DbInit : IDbInit
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

        public DbInit(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
			_roleManager = roleManager;
			_userManager = userManager;
        }
		public async Task RoleSeed()
		{
			// چیک کریں کہ "Admin" رول موجود ہے یا نہیں
			if (!await _roleManager.RoleExistsAsync("Admin"))
			{
				await _roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			// چیک کریں کہ "Customer" رول موجود ہے یا نہیں
			if (!await _roleManager.RoleExistsAsync("Customer"))
			{
				await _roleManager.CreateAsync(new IdentityRole("Customer"));
			}

			// ایڈمن یوزر کو چیک کریں
			var adminUser = await _userManager.FindByEmailAsync("Admin@gmail.com");
			if (adminUser != null && !await _userManager.IsInRoleAsync(adminUser, "Admin"))
			{
				await _userManager.AddToRoleAsync(adminUser, "Admin");
			}

			// دوسرے یوزرز کو بھی ایڈمن رول دینے کا لاجک
			var otherAdminUsers = await _userManager.Users.ToListAsync();
			foreach (var user in otherAdminUsers)
			{
				if (user.Email != "Admin@gmail.com" && !await _userManager.IsInRoleAsync(user, "Admin"))
				{
					// اگر یوزر کا ای میل ایڈمن نہیں ہے تو اسے "Customer" رول دیں
					//await _userManager.AddToRoleAsync(user, "Customer");
				}
				else if (!await _userManager.IsInRoleAsync(user, "Admin"))
				{
					// اگر یوزر کا ای میل ایڈمن ہے تو اسے "Admin" رول دیں
					await _userManager.AddToRoleAsync(user, "Admin");
				}
			}
		}
	}
}
