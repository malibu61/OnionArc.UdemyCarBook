﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;
using UdemyCarBook.Application.Interfaces.PricingInterfaces;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);

            return values.Select(x => new GetRentACarQueryResult
            {
                CarId = x.CarID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model,
                Amount = x.Car.CarPricings.Where(y => y.PricingID == 2 && y.CarID == x.CarID).FirstOrDefault().Amount
            }).ToList();
        }
    }
}
