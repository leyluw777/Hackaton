using HackatonCode8.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Application.AppUser.DeviceRegisterUser.Commands
{
	public class DeviceRegisterUserRequestCommand : IRequest<IDataResult<DeviceRegisterUserRequestCommand>>
	{
		public string DeviceId { get; set; }
	}

}
