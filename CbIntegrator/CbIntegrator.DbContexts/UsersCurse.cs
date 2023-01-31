using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CbIntegrator.DbContexts
{

	[Table("users_Course")]
	public record UsersCurse
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id_users_course")]
		public int Id { get; set; }
		[Column("user_id")]
        [ForeignKey("UsersTable")]
		public string UserId { get; set; }
		public UsersTable UsersTable { get; set; }

		[Column("course_name")]
		public string CurseName { get; set; }

	}
}
