using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CbIntegrator.DbContexts
{

	[Table("Users_Curse")]
	public record UsersCurse
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id_users_course")]
		public int Id { get; set; }
		[Column("user_id")]
		public string UserId { get; set; }
		[Column("course_name")]
		public string CurseName { get; set; }
	}
}
