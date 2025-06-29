using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;

namespace UdemyCarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly CreateCarHandler _createCarHandler;
        private readonly UpdateCarHandler _updateCarHandler;
        private readonly RemoveCarHandler _removeCarHandler;
        private readonly GetCarByBrandQueryHandler _getCarByBrandQueryHandler;
        private readonly GetLast5CarsWithBrandsQueryHandler _getLast5CarsWithBrandsQueryHandler;

        public CarController(GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, CreateCarHandler createCarHandler, UpdateCarHandler updateCarHandler, RemoveCarHandler removeCarHandler, GetCarByBrandQueryHandler getCarByBrandQueryHandler, GetLast5CarsWithBrandsQueryHandler getLast5CarsWithBrandsQueryHandler)
        {
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _createCarHandler = createCarHandler;
            _updateCarHandler = updateCarHandler;
            _removeCarHandler = removeCarHandler;
            _getCarByBrandQueryHandler = getCarByBrandQueryHandler;
            _getLast5CarsWithBrandsQueryHandler = getLast5CarsWithBrandsQueryHandler;
        }


        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var values = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarHandler.Handle(command);
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarHandler.Handle(command);
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _removeCarHandler.Handle(new RemoveCarCommand(id));
            return Ok("Silme Başarılı");
        }

        [HttpGet("CarListWBrand")]
        public async Task<IActionResult> CarListWBrand()
        {
            var values = await _getCarByBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("Last5CarListWBrand")]
        public async Task<IActionResult> Last5CarListWBrand()
        {
            var values = await _getLast5CarsWithBrandsQueryHandler.Handle();
            return Ok(values);
        }
    }

}
