using DynamicallyRole.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DynamicAuthorization.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using DynamicallyRole.Data;
using Microsoft.AspNetCore.Identity;

namespace DynamicallyRole.Controllers
{
	[DisplayName("Home page")]
	[Authorize]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
		{
            _logger = logger;


           /* _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;

			if (_signInManager.IsSignedIn(User))
			{
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				var adminId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			}*/


        }

		[DisplayName("Index")]
		public IActionResult Index()
		{


			return View();
		}

		[DisplayName("Privacy")]
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
