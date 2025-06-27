using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommand;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;

namespace UdemyCarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly GetBrandByIdHandler _getBrandByIdHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly CreateBrandHandler _createBrandHandler;
        private readonly UpdateBrandHandler _updateBrandHandler;
        private readonly RemoveBrandHandler _removeBrandHandler;

        public BrandController(GetBrandByIdHandler getBrandByIdHandler, GetBrandQueryHandler getBrandQueryHandler, CreateBrandHandler createBrandHandler, UpdateBrandHandler updateBrandHandler, RemoveBrandHandler removeBrandHandler)
        {
            _getBrandByIdHandler = getBrandByIdHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _createBrandHandler = createBrandHandler;
            _updateBrandHandler = updateBrandHandler;
            _removeBrandHandler = removeBrandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var values = await _getBrandByIdHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandHandler.Handle(command);
            return Ok("Ekleme Başarılı");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
             await _updateBrandHandler.Handle(command);
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Silme Başarılı");
        }
    }
}
