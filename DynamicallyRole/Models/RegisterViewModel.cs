using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DynamicallyRole.Models
{
	public class RegisterViewModel
	{
		[Required]
		public string Name { get; set; }

		[Required] public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} charactor long", MinimumLength = 6)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The Password and confirm Password not same")]

		public string ConfirmPassword { get; set; }

		public IEnumerable<SelectListItem>? RoleList { get; set; }
		[Display(Name = "Role Selected")]
		public string RoleSelected { get; set; }
	}

}
