using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.LocationInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly ILocationRepository _repository;

        public GetLocationCountQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLocationCount();
            return new GetLocationCountQueryResult
            {
                LocationCount = values
            };
        }
    }
}
