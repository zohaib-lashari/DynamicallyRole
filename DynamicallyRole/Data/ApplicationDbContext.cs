using DynamicallyRole.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DynamicallyRole.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<RoleAccess> RoleAccess { get; set; }
    }
}
