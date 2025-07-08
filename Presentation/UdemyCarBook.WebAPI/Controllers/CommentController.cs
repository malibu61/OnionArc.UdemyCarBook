using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.RepositoryDesign;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Dto.CommentDtos;

namespace UdemyCarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _genericRepository;

        public CommentController(IGenericRepository<Comment> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = _genericRepository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var values = _genericRepository.GetById(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            _genericRepository.Create(comment);
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            _genericRepository.Update(comment);
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            _genericRepository.Remove(id);
            return Ok("Silme Başarılı");
        }

        [HttpGet("GetCommentByBlogId")]
        public async Task<IActionResult> GetCommentByBlogId(int id)
        {
            var values = _genericRepository.GetCommentByBlogId(id);

            return Ok(values.Select(x => new ResultCommentDto
            {
                BlogID = x.BlogID,
                BlogName = x.Blog.Title,
                CommentID = x.CommentID,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name
            }));
        }
    }
}
