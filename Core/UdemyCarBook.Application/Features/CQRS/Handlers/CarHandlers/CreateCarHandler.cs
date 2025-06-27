using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car()
            {
                Transmission=command.Transmission,
                BigImageUrl=command.BigImageUrl,
                BrandID=command.BrandID,
                Luggage = command.Luggage,
                Km = command.Km,
                Model = command.Model,
                Seat = command.Seat,
                CoverImageUrl = command.CoverImageUrl,
                Fuel = command.Fuel
            });
        }
    }
}
