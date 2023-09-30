using HackatonCode8.Application.AppUser.LoginUser.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HackatonCode8.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : Controller
	{
		IMediator _mediator;

		public LoginController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginUserRequestCommand loginUserCommandRequest)
		{
			
			LoginUserResponseCommand loginUser = await _mediator.Send(loginUserCommandRequest);

			return Ok(loginUser.Token);

		}
	}
}
