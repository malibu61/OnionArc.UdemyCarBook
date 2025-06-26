using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandle
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandle(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        //public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQueryResult query)
        //{
        //    var values = await _repository.GetByIdAsync(query.BannerID);

        //    return new GetBannerByIdQueryResult()
        //    {
        //        BannerID = query.BannerID,
        //        Description = query.Description,
        //        Title = query.Title,
        //        VideoDescription = query.VideoDescription,
        //        VideoUrl=query.VideoUrl
        //    };


        //}

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);

            return new GetBannerByIdQueryResult
            {
                BannerID = values.BannerID,
                Description = values.Description,
                Title = values.Title,
                VideoDescription = values.VideoDescription,
                VideoUrl = values.VideoUrl
            };
        }
    }
}
