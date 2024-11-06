﻿using DynamicallyRole.Data;
using DynamicallyRole.Models;
using DynamicallyRole.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace DynamicallyRole.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly ApplicationDbContext _context;
		

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,SignInManager<IdentityUser> signInManager,ApplicationDbContext context)
        {
            _userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_context = context;
			
        }

		[AllowAnonymous]
        public IActionResult Login()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
                List<RoleViewModel> roleViewModels = new List<RoleViewModel>();

                var result = await _signInManager.PasswordSignInAsync(model.username, model.Password, model.RememberMe,lockoutOnFailure:false);

				


				return RedirectToAction("Index","Home");
			}
			return View(model);
		}

		public IActionResult Reg()
		{
			/*var claimsIdentity = (ClaimsIdentity)User.Identity;
			var adminId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;*/
			RegisterViewModel model = new RegisterViewModel()
			{


				RoleList = _roleManager.Roles.Select(x => x.Name).Select(n => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
				{
					Text = n,
					Value = n
				})
			};
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{

			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var adminId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			if (ModelState.IsValid)
			{
				var user = new IdentityUser
				{
					UserName = model.Email,
					Email = model.Email,
					EmailConfirmed = true
				};

				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					if (model.RoleSelected != null && model.RoleSelected.Length > 0)
					{
						await _userManager.AddToRoleAsync(user, model.RoleSelected);
					}
					else
					{
						await _userManager.AddToRoleAsync(user, "Customer");
					}
				}

			}
			return RedirectToAction("Reg");
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogOff()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}


		[AllowAnonymous]
        public IActionResult NoAccess()
        {
            return View();
        }


    }
}
