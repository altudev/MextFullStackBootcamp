using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandHandler:IRequestHandler<UserAuthRegisterCommand,ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;

        public UserAuthRegisterCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task<ResponseDto<JwtDto>> Handle(UserAuthRegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
