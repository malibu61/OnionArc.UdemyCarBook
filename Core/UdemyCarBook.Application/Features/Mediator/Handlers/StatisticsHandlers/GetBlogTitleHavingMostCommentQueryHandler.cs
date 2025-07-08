using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBlogTitleHavingMostCommentQueryHandler : IRequestHandler<GetBlogTitleHavingMostCommentQuery, GetBlogTitleHavingMostCommentQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogTitleHavingMostCommentQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTitleHavingMostCommentQueryResult> Handle(GetBlogTitleHavingMostCommentQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.BlogTitleHavingMostComment();
            return new GetBlogTitleHavingMostCommentQueryResult
            {
                BlogTitleHavingMostComment = values
            };
        }
    }
}
