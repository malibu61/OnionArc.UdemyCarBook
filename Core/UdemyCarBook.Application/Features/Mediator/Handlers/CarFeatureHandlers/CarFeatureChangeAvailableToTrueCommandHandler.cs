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
    public class CarFeatureChangeAvailableToTrueCommandHandler : IRequestHandler<CarFeatureChangeAvailableToTrueCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public CarFeatureChangeAvailableToTrueCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CarFeatureChangeAvailableToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToTrue(request.CarID, request.FeatureID);
        }
    }
}
