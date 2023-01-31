using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CbIntegrator.DbContexts
{
	[Table("Users")]
	public record UsersTable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string Password { get; set; }
		public string Login { get; set; }

		public ICollection<UsersCurse> usersCurses { get; set; }

	}
}