using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult()
            {
                Transmission = values.Transmission,
                CarID = values.CarID,
                BigImageUrl = values.BigImageUrl,
                BrandID = values.BrandID,
                Luggage = values.Luggage,
                Km = values.Km,
                Model = values.Model,
                Seat = values.Seat,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel
            };
        }

    }
}
