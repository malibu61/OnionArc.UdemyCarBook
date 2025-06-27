using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarID);
            values.Transmission = command.Transmission;
            values.BigImageUrl = command.BigImageUrl;
            values.BrandID = command.BrandID;
            values.Luggage = command.Luggage;
            values.Km = command.Km;
            values.Model = command.Model;
            values.Seat = command.Seat;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Fuel = command.Fuel;
            await _repository.UpdateAsync(values);

        }
    }
}
