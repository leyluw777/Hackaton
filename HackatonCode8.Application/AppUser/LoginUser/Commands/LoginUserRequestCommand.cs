using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Application.AppUser.LoginUser.Commands
{
	public class LoginUserRequestCommand : IRequest<LoginUserResponseCommand>
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
