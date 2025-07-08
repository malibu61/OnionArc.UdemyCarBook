using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetDieselCarCountQueryHandler : IRequestHandler<GetDieselCarCountQuery, GetDieselCarCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetDieselCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDieselCarCountQueryResult> Handle(GetDieselCarCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.DieselCarCount();
            return new GetDieselCarCountQueryResult
            {
                DieselCarCount = values
            };
        }
    }
}
