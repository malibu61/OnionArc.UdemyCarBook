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
    public class GetBrandNameHavingMostCarQueryHandler : IRequestHandler<GetBrandNameHavingMostCarQuery, GetBrandNameHavingMostCarQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandNameHavingMostCarQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandNameHavingMostCarQueryResult> Handle(GetBrandNameHavingMostCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.BrandNameHavingMostCar();
            return new GetBrandNameHavingMostCarQueryResult
            {
                BrandNameHavingMostCar = values
            };
        }
    }
}
