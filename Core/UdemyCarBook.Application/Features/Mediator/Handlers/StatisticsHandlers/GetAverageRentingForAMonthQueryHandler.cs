﻿using MediatR;
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
    public class GetAverageRentingForAMonthQueryHandler : IRequestHandler<GetAverageRentingForAMonthQuery, GetAverageRentingForAMonthQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAverageRentingForAMonthQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAverageRentingForAMonthQueryResult> Handle(GetAverageRentingForAMonthQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.AverageRentingForAMonth();
            return new GetAverageRentingForAMonthQueryResult
            {
                AverageRentingForAMonth = values
            };
        }
    }
}
