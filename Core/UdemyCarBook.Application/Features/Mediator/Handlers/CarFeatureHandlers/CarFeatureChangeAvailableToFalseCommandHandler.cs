using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CarFeatureChangeAvailableToFalseCommandHandler : IRequestHandler<CarFeatureChangeAvailableToFalseCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public CarFeatureChangeAvailableToFalseCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CarFeatureChangeAvailableToFalseCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToFalse(request.CarID, request.FeatureID);
        }
    }
}
