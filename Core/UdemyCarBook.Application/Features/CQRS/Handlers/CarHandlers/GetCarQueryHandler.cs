﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values=await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult()
            {
                Transmission = x.Transmission,
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
    }
}
