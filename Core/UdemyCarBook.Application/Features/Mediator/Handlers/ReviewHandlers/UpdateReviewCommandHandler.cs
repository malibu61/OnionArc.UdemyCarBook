using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;
        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ReviewId);
            values.CustomerName = request.CustomerName;
            values.ReviewDate = request.ReviewDate;
            values.CarId = request.CarId;
            values.Comment = request.Comment;
            values.RatingValue = request.RatingValue;
            await _repository.UpdateAsync(values);
        }
    }
}
