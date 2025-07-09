using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;

namespace UdemyCarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarsWithPricingAndBrand")]
        public async Task<IActionResult> GetCarsWithPricingAndBrand()
        {
            var values = await _mediator.Send(new GetCarsWithPricingAndBrandQuery());
            return Ok(values);
        }


        [HttpGet("GetCarsWPricingAndBrandWithTimePeriod")]
        public async Task<IActionResult> GetCarsWPricingAndBrandWithTimePeriod()
        {
            var values = await _mediator.Send(new GetCarsWPricingAndBrandWithTimePeriodQuery());
            return Ok(values);
        }
    }
}
