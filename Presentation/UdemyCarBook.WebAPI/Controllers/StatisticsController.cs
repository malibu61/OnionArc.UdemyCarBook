using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;

namespace UdemyCarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountWithAutomaticTransmission")]
        public async Task<IActionResult> GetCarCountWithAutomaticTransmission()
        {
            var values = await _mediator.Send(new GetCarCountWithAutomaticTransmissionQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountWithManuelTransmission")]
        public async Task<IActionResult> GetCarCountWithManuelTransmission()
        {
            var values = await _mediator.Send(new GetCarCountWithManuelTransmissionQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandNameHavingMostCar")]
        public async Task<IActionResult> GetBrandNameHavingMostCar()
        {
            var values = await _mediator.Send(new GetBrandNameHavingMostCarQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogTitleHavingMostComment")]
        public async Task<IActionResult> GetBlogTitleHavingMostComment()
        {
            var values = await _mediator.Send(new GetBlogTitleHavingMostCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetAverageRentingForADay")]
        public async Task<IActionResult> GetAverageRentingForADay()
        {
            var values = await _mediator.Send(new GetAverageRentingForADayQuery());
            return Ok(values);
        }

        [HttpGet("GetAverageRentingForAWeek")]
        public async Task<IActionResult> GetAverageRentingForAWeek()
        {
            var values = await _mediator.Send(new GetAverageRentingForAWeekQuery());
            return Ok(values);
        }

        [HttpGet("GetAverageRentingForAMonth")]
        public async Task<IActionResult> GetAverageRentingForAMonth()
        {
            var values = await _mediator.Send(new GetAverageRentingForAMonthQuery());
            return Ok(values);
        }


        [HttpGet("GetMostExpensiveCar")]
        public async Task<IActionResult> GetMostExpensiveCar()
        {
            var values = await _mediator.Send(new GetMostExpensiveCarQuery());
            return Ok(values);
        }

        [HttpGet("GetTheCheapestCar")]
        public async Task<IActionResult> GetTheCheapestCar()
        {
            var values = await _mediator.Send(new GetTheCheapestCarQuery());
            return Ok(values);
        }

        [HttpGet("GetGasolineCarCount")]
        public async Task<IActionResult> GetGasolineCarCount()
        {
            var values = await _mediator.Send(new GetGasolineCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetDieselCarCount")]
        public async Task<IActionResult> GetDieselCarCount()
        {
            var values = await _mediator.Send(new GetDieselCarCountQuery());
            return Ok(values);
        }
    }



}
