using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogAndAuthorByBlogIdQueryHandler : IRequestHandler<GetBlogAndAuthorByBlogIdQuery, GetBlogAndAuthorByBlogIdQueryResult>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogAndAuthorByBlogIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogAndAuthorByBlogIdQueryResult> Handle(GetBlogAndAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetBlogAndAuthorByBlogId(request.Id);
            return new GetBlogAndAuthorByBlogIdQueryResult
            {
                AuthorDescription = values.Author.Description,
                Description = values.Description,
                AuthorID = values.AuthorID,
                AuthorImageUrl = values.Author.ImageUrl,
                AuthorName = values.Author.Name,
                BlogID = values.BlogID,
                Body = values.Body,
                CategoryID = values.CategoryID,
                CoverImageUrl = values.CoverImageUrl,
                CreatedDate = values.CreatedDate,
                Title = values.Title
            };
        }
    }
}
