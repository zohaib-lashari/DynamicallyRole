using DynamicallyRole.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DynamicAuthorization.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;

namespace DynamicallyRole.Controllers
{
	[DisplayName("Home page")]
	[Authorize]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
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
