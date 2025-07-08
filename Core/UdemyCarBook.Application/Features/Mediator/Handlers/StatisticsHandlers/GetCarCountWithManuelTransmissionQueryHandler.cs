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
    public class GetCarCountWithManuelTransmissionQueryHandler : IRequestHandler<GetCarCountWithManuelTransmissionQuery, GetCarCountWithManuelTransmissionQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountWithManuelTransmissionQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountWithManuelTransmissionQueryResult> Handle(GetCarCountWithManuelTransmissionQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.CarCountWithManuelTransmission();
            return new GetCarCountWithManuelTransmissionQueryResult
            {
                CarCountWithManuelTransmission = values
            };
        }
    }
}
