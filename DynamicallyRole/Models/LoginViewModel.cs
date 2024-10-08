using System.ComponentModel.DataAnnotations;

namespace DynamicallyRole.Models
{
	public class LoginViewModel
	{

		[Required]
		public string username {  get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberMe { get; set; }

	}
}
