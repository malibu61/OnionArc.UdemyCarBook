using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace UdemyCarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    { ////GetCarFeatureByCarIdQueryHandler
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarFeaturesByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPost("ChangeCarFeatureAvailableToTrue")]
        public async Task<IActionResult> ChangeCarFeatureAvailableToTrue(CarFeatureChangeAvailableToTrueCommand command)
        {
            await _mediator.Send(command);
            return Ok(command.CarID + " " + command.FeatureID + "True'ya çevrildi");
        }

        [HttpPost("ChangeCarFeatureAvailableToFalse")]
        public async Task<IActionResult> ChangeCarFeatureAvailableToFalse(CarFeatureChangeAvailableToFalseCommand command)
        {
            await _mediator.Send(command);
            return Ok(command.CarID + " " + command.FeatureID + "False'a çevrildi");
        }

        [HttpPost("AssingCarFeatureAvailableToNewOne")]
        public async Task<IActionResult> AssingCarFeatureAvailableToNewOne(AssingCarFeatureAvailableToNewOneCommand command)
        {
            await _mediator.Send(command);
            return Ok(command.CarID + " " + command.FeatureID + " " + command.Available + " Olarak Eklendi;)");
        }

    }
}
