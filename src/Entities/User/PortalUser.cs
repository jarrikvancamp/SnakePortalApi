using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.PlayerScore;

namespace Entities.User
{
	public class PortalUser : AuditEntityBase
	{
		public virtual List<Score> Scores { get; set; }

		[Required]
		[MaxLength(128)]
		public string UserName { get; set; }
		[Required]
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int SexId { get; set; }
		public int NationalityId { get; set; }
		public int LocationId { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Salt { get; set; }
	}
}