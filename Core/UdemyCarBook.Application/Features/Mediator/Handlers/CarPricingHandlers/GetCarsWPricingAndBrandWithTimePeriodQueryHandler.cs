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
    public class GetCarsWPricingAndBrandWithTimePeriodQueryHandler : IRequestHandler<GetCarsWPricingAndBrandWithTimePeriodQuery, List<GetCarsWPricingAndBrandWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarsWPricingAndBrandWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarsWPricingAndBrandWithTimePeriodQueryResult>> Handle(GetCarsWPricingAndBrandWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _carPricingRepository.GetCarsWithPricingWTimePeriod();
            return values.Select(x => new GetCarsWPricingAndBrandWithTimePeriodQueryResult
            {
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CarId = x.CarID,
                CarPricingId = x.CarPricingID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                TimePeriodDaily = x.Car.CarPricings.Where(y => y.PricingID == 2).FirstOrDefault()?.Amount ?? 0,
                TimePeriodWeekly = x.Car.CarPricings.Where(y => y.PricingID == 3).FirstOrDefault()?.Amount ?? 0,
                TimePeriodMonthly = x.Car.CarPricings.Where(y => y.PricingID == 4).FirstOrDefault()?.Amount ?? 0
            }).ToList();
        }
    }
}
