using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicallyRole.Models
{
    public class RoleAccess
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string Access { get; set; }


    }
}
