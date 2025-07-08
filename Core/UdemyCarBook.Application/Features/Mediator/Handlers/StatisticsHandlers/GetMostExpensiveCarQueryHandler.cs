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
    public class GetMostExpensiveCarQueryHandler : IRequestHandler<GetMostExpensiveCarQuery, GetMostExpensiveCarQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetMostExpensiveCarQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMostExpensiveCarQueryResult> Handle(GetMostExpensiveCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.MostExpensiveCar();
            return new GetMostExpensiveCarQueryResult
            {
                MostExpensiveCar = values
            };
        }
    }
}
