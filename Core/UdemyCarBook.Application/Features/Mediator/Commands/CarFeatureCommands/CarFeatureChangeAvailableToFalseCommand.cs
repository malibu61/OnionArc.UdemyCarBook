using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CarFeatureChangeAvailableToFalseCommand : IRequest
    {
        public int FeatureID { get; set; }
        public int CarID { get; set; }
    }
}
