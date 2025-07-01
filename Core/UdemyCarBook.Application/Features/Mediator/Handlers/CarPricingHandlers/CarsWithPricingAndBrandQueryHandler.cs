using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.PricingInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class CarsWithPricingAndBrandQueryHandler : IRequestHandler<GetCarsWithPricingAndBrandQuery, List<GetCarsWithPricingAndBrandQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public CarsWithPricingAndBrandQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarsWithPricingAndBrandQueryResult>> Handle(GetCarsWithPricingAndBrandQuery request, CancellationToken cancellationToken)
        {
            var values = _carPricingRepository.GetCarsWithPricing();
            return values.Select(x => new GetCarsWithPricingAndBrandQueryResult
            {
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CarId = x.CarID,
                CarPricingId = x.CarPricingID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model
            }).ToList();
        }
    }
}
