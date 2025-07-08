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
    public class GetCarCountWithAutomaticTransmissionQueryHandler : IRequestHandler<GetCarCountWithAutomaticTransmissionQuery, GetCarCountWithAutomaticTransmissionQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountWithAutomaticTransmissionQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountWithAutomaticTransmissionQueryResult> Handle(GetCarCountWithAutomaticTransmissionQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.CarCountWithAutomaticTransmission();
            return new GetCarCountWithAutomaticTransmissionQueryResult
            {
                CarCountWithAutomaticTransmission = values
            };
        }
    }
}
