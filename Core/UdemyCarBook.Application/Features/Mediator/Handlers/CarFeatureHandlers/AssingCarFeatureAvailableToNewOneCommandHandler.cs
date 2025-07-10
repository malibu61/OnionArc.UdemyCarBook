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
    public class AssingCarFeatureAvailableToNewOneCommandHandler : IRequestHandler<AssingCarFeatureAvailableToNewOneCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public AssingCarFeatureAvailableToNewOneCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AssingCarFeatureAvailableToNewOneCommand request, CancellationToken cancellationToken)
        {
            _repository.AssingCarFeatureAvailableToNewOne(request.CarID, request.FeatureID, request.Available);
        }
    }
}
