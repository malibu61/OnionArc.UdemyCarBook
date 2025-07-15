using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IAppUserRepository _repository;

        public GetCheckAppUserQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                return new GetCheckAppUserQueryResult
                {
                    IsExist = false
                };
            }
            else
            {
                return new GetCheckAppUserQueryResult
                {
                    IsExist = true,
                    Username = user.Username,
                    Role = user.AppRole.AppRoleName,
                    Id = user.AppUserId
                };
               
            }            

        }
    }
}
