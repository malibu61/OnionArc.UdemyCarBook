using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentByMediatorCommandHandler : IRequestHandler<CreateCommentByMediatorCommand>
    {
        private readonly IRepository<Comment> _repository;

        public CreateCommentByMediatorCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentByMediatorCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Comment
            {
                BlogID = request.BlogID,
                CreatedDate = DateTime.Now,
                Description = request.Description,
                Email = request.Email,
                Name = request.Name
            });
        }
    }
}
