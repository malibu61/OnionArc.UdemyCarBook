using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;

namespace UdemyCarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var values = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Silme İşlemi Başarılı");
        }
    }
}
