using HackatonCode8.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;


namespace HackatonCode8.Infrastructure.Persistence.Services
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUserService(IHttpContextAccessor accessor)
        => _accessor = accessor;

        public string? UserName => _accessor.HttpContext.User.Identity.Name;
    }
}
