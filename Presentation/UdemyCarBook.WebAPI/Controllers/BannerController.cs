using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;

namespace UdemyCarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly CreateBannerHandler _createBannerHandler;
        private readonly UpdateBannerHandler _updateBannerHandler;
        private readonly RemoveBannerHandler _removeBannerHandler;
        private readonly GetBannerByIdQueryHandle _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;

        public BannerController(CreateBannerHandler createBannerHandler, UpdateBannerHandler updateBannerHandler, RemoveBannerHandler removeBannerHandler, GetBannerByIdQueryHandle getBannerByIdQueryHandle, GetBannerQueryHandler getBannerQueryHandler)
        {
            _createBannerHandler = createBannerHandler;
            _updateBannerHandler = updateBannerHandler;
            _removeBannerHandler = removeBannerHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandle;
            _getBannerQueryHandler = getBannerQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            var values = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerHandler.Handle(command);
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerHandler.Handle(command);
            return Ok("Güncelleme Başarılı");
        }

        //[HttpDelete]
        //public async Task<IActionResult> RemoveBanner(RemoveBannerCommand command)
        //{
        //    await _removeBannerHandler.Handle(command);
        //    return Ok("Silme Başarılı");
        //}

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Silme Başarılı");
        }

    }
}
