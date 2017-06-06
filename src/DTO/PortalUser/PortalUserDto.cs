using System;

namespace DTO.PortalUser
{
	public class PortalUserDto : AuditDtoBase
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int SexId { get; set; }
		public int NationalityId { get; set; }
		public int LocationId { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
	}
}