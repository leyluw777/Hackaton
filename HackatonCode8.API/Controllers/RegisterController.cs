using HackatonCode8.Application.AppUser.DeviceRegisterUser.Commands;
using HackatonCode8.Application.AppUser.LoginUser.Commands;
using HackatonCode8.Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackatonCode8.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : Controller
	{
		IMediator _mediator;

		public RegisterController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Register(DeviceRegisterUserRequestCommand registerUserCommandRequest)
		{

			IDataResult<DeviceRegisterUserRequestCommand> registerUser = await _mediator.Send(registerUserCommandRequest);

			return Ok(registerUser);
		}
		}
	}
