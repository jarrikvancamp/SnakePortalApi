using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePortal.Shared.Models
{
	public class LoginModel
	{
		public bool IsCorrectLogin { get; set; }
		public string Token { get; set; }
		public int UserId { get; set; }
	}
}
