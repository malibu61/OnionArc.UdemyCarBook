using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Application.Interfaces.FeatureInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _featureRepository1;
        private readonly IFeatureRepository _featureRepository2;
        private readonly ICarFeatureRepository _carFeatureRepository1;
        private readonly IRepository<CarFeature> _carFeatureRepository2;

        public CreateFeatureCommandHandler(IRepository<Feature> featureRepository1, IFeatureRepository featureRepository2, ICarFeatureRepository carFeatureRepository1, IRepository<CarFeature> carFeatureRepository2)
        {
            _featureRepository1 = featureRepository1;
            _featureRepository2 = featureRepository2;
            _carFeatureRepository1 = carFeatureRepository1;
            _carFeatureRepository2 = carFeatureRepository2;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _featureRepository1.CreateAsync(new Feature()
            {
                Name = request.Name
            });

            foreach (var item in _carFeatureRepository1.WhenFeatureCreatedAddToAllCarsOnCarFeaturesByFalse())
            {
                await _carFeatureRepository2.CreateAsync(new CarFeature()
                {
                    Available = false,
                    CarID = item,
                    FeatureID = _featureRepository2.GetLastCreatedFeatureId()
                });
            }


        }

    }
}
