﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogAndAuthorByBlogIdQuery : IRequest<GetBlogAndAuthorByBlogIdQueryResult>
    {
        public int Id { get; set; }

        public GetBlogAndAuthorByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
