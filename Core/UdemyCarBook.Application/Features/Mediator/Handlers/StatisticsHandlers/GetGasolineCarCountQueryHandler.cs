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
    public class GetGasolineCarCountQueryHandler : IRequestHandler<GetGasolineCarCountQuery, GetGasolineCarCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetGasolineCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetGasolineCarCountQueryResult> Handle(GetGasolineCarCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GasolineCarCount();
            return new GetGasolineCarCountQueryResult
            {
                GasolineCarCount = values
            };
        }
    }
}
