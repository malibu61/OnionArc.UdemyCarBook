using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries
{
    public class GetReviewsByCarIdQuery : IRequest<List<GetReviewsByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetReviewsByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
