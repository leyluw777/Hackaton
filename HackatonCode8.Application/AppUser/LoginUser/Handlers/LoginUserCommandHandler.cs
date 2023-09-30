using Azure.Core;
using HackatonCode8.Application.AppUser.LoginUser.Commands;
using HackatonCode8.Application.Common.Interfaces;
using HackatonCode8.Application.Common.JWT;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonCode8.Domain.Identity;

namespace HackatonCode8.Application.AppUser.LoginUser.Handlers
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserRequestCommand, LoginUserResponseCommand>
	{
		private readonly ITokenHandler _tokenHandler;
		private readonly UserManager<HackatonCode8.Domain.Identity.AppUser> _userManager;
		private readonly IApplicationDbContext _dbContext;

		public LoginUserCommandHandler(ITokenHandler tokenHandler, UserManager<Domain.Identity.AppUser> userManager, IApplicationDbContext dbContext)
		{
			_tokenHandler = tokenHandler;
			_userManager = userManager;
			_dbContext = dbContext;
		}

		public async Task<LoginUserResponseCommand> Handle(LoginUserRequestCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByNameAsync(request.Username);


			if (user == null) throw new Exception("User not found");
			var result = await _userManager.CheckPasswordAsync(user, request.Password);

			if (!result) throw new Exception("Authentication error");
			//var accessToken = await _tokenHandler.CreateAccessToken(1200, user);

			return new LoginUserResponseCommand()
			{
				Token = null,

			};
		}
	}
}
