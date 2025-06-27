using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarByBrandQueryHandler(ICarRepository carRepository)
        {
            _repository = carRepository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = _repository.GetCarsWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult()
            {
                Transmission = x.Transmission,
                BrandName = x.Brand.Name,
                CarID = x.CarID,
                BigImageUrl = x.BigImageUrl,
                BrandID = x.BrandID,
                Luggage = x.Luggage,
                Km = x.Km,
                Model = x.Model,
                Seat = x.Seat,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel
            }).ToList();
        }
        //public async Task<List<GetCarWithBrandQueryResult>> Handle()
        //{
        //    var values = await _repository.GetCarsWithBrands(); // await unutulmasın

        //    return values.Select(x => new GetCarWithBrandQueryResult()
        //    {
        //        Transmission = x.Transmission,
        //        BrandName = x.Brand?.Name ?? "Markasız", // null kontrolü
        //        CarID = x.CarID,
        //        BigImageUrl = x.BigImageUrl,
        //        BrandID = x.BrandID,
        //        Luggage = x.Luggage,
        //        Km = x.Km,
        //        Model = x.Model,
        //        Seat = x.Seat,
        //        CoverImageUrl = x.CoverImageUrl,
        //        Fuel = x.Fuel
        //    }).ToList();
        //}

        //public async Task<List<GetCarWithBrandQueryResult>> Handle()
        //{
        //    var values = _repository.GetCarsWithBrands();

        //    var result = values.Select(x => new GetCarWithBrandQueryResult()
        //    {
        //        Transmission = x.Transmission,
        //        BrandName = x.Brand?.Name ?? "Markasız",
        //        CarID = x.CarID,
        //        BigImageUrl = x.BigImageUrl,
        //        BrandID = x.BrandID,
        //        Luggage = x.Luggage,
        //        Km = x.Km,
        //        Model = x.Model,
        //        Seat = x.Seat,
        //        CoverImageUrl = x.CoverImageUrl,
        //        Fuel = x.Fuel
        //    }).ToList();

        //    return Task.FromResult(result); // ✅ Task olarak dönüyoruz
        //}


    }
}
