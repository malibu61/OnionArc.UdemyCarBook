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
    public class GetTheCheapestCarQueryHandler : IRequestHandler<GetTheCheapestCarQuery, GetTheCheapestCarQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetTheCheapestCarQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTheCheapestCarQueryResult> Handle(GetTheCheapestCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.TheCheapestCar();
            return new GetTheCheapestCarQueryResult
            {
                TheCheapestCar = values
            };
        }
    }
}
