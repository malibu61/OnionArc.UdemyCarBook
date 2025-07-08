using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces.AuthorInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorCountQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var values = _authorRepository.AuthorCount();
            return new GetAuthorCountQueryResult
            {
                AuthorCount = values
            };
        }
    }
}
