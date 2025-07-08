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
    public class GetAverageRentingForAWeekQueryHandler : IRequestHandler<GetAverageRentingForAWeekQuery, GetAverageRentingForAWeekQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAverageRentingForAWeekQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAverageRentingForAWeekQueryResult> Handle(GetAverageRentingForAWeekQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.AverageRentingForAWeek();
            return new GetAverageRentingForAWeekQueryResult
            {
                AverageRentingForAWeek = values
            };
        }
    }
}
