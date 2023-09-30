using HackatonCode8.Application.DTOs;
using HackatonCode8.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Application.Common.JWT
{
    public interface ITokenHandler
    {
        Task<TokenDto> CreateAccessToken(int second, HackatonCode8.Domain.Identity.AppUser appUser);

    }
}
