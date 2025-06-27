using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;

namespace UdemyCarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly RemoveCategoryHandler _removeCategoryHandler;
        private readonly UpdateCategoryHandler _updateCategoryHandler;
        private readonly CreateCategoryHandler _createCategoryHandler;

        public CategoryController(GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, RemoveCategoryHandler removeCategoryHandler, UpdateCategoryHandler updateCategoryHandler, CreateCategoryHandler createCategoryHandler)
        {
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _removeCategoryHandler = removeCategoryHandler;
            _updateCategoryHandler = updateCategoryHandler;
            _createCategoryHandler = createCategoryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var values = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryHandler.Handle(command);
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryHandler.Handle(command);
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryHandler.Handler(new RemoveCategoryCommand(id));
            return Ok("Silme Başarılı");
        }
    }
}
