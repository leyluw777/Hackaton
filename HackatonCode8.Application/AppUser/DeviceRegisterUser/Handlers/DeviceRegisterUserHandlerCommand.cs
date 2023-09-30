using HackatonCode8.Application.AppUser.DeviceRegisterUser.Commands;
using HackatonCode8.Application.Common.Interfaces;
using HackatonCode8.Application.Common.Results;
using HackatonCode8.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Application.AppUser.DeviceRegisterUser.Handlers
{
	public class DeviceRegisterUserHandlerCommand : IRequestHandler<DeviceRegisterUserRequestCommand, IDataResult<DeviceRegisterUserRequestCommand>>
	{
		private readonly IApplicationDbContext _appDbContext;

		public DeviceRegisterUserHandlerCommand(IApplicationDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<IDataResult<DeviceRegisterUserRequestCommand>> Handle(DeviceRegisterUserRequestCommand request, CancellationToken cancellationToken)
		{
			User newDevice = new()
			{
				DeviceId = request.DeviceId,
			};

			await _appDbContext.Users.AddAsync(newDevice);
			await _appDbContext.SaveChangesAsync(cancellationToken);


			return new SuccessDataResult<DeviceRegisterUserRequestCommand>(request, " New device added successfully");

		}
	}
}
