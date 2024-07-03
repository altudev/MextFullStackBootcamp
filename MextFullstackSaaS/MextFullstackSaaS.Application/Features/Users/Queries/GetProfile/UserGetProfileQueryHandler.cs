using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.Application.Features.Users.Queries.GetProfile
{
    public class UserGetProfileQueryHandler:IRequestHandler<UserGetProfileQuery, UserGetProfileDto>
    {
        private readonly IIdentityService _identityService;

        public UserGetProfileQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task<UserGetProfileDto> Handle(UserGetProfileQuery request, CancellationToken cancellationToken)
        {
            return _identityService.GetProfileAsync(cancellationToken);
        }
    }
}
