using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewsByCarIdQueryHandler : IRequestHandler<GetReviewsByCarIdQuery, List<GetReviewsByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;

        public GetReviewsByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        //public async Task<GetReviewsByCarIdQueryResult> Handle(GetReviewsByCarIdQuery request, CancellationToken cancellationToken)
        //{
        //    //var values = _repository.GetReviewsByCarId(request.Id);
        //    //return values.Select(x => new GetReviewsByCarIdQueryResult
        //    //{
        //    //    CarId = x.CarId,
        //    //    Comment = x.Comment,
        //    //    CustomerImage = x.CustomerImage,
        //    //    CustomerName = x.CustomerName,
        //    //    RatingValue = x.RatingValue,
        //    //    ReviewDate = x.ReviewDate,
        //    //    ReviewId = x.ReviewId
        //    //}).ToList();
        //}

       public async Task<List<GetReviewsByCarIdQueryResult>>  Handle(GetReviewsByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetReviewsByCarId(request.Id).ToList();
            return values.Select(x => new GetReviewsByCarIdQueryResult
            {
                CarId = x.CarId,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                RatingValue = x.RatingValue,
                ReviewDate = x.ReviewDate,
                ReviewId = x.ReviewId
            }).ToList();
        }


    }
}
