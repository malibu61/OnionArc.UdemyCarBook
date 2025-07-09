using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandByCarIdQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandByCarIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<GetCarWithBrandByCarIdQueryResult> Handle(GetCarWithBrandByCarIdQuery query)
        {
            var values = _carRepository.GetCarWithBrandByCarId(query.Id);
            return new GetCarWithBrandByCarIdQueryResult
            {
                BigImageUrl = values.BigImageUrl,
                BrandID = values.BrandID,
                CarID = values.CarID,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seat = values.Seat,
                Transmission = values.Transmission,
                BrandName = values.Brand.Name
            };
        }
    }
}
