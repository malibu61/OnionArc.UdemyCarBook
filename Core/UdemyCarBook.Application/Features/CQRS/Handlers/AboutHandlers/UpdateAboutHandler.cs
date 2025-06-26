using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            await _repository.UpdateAsync(new About
            {
                AboutID = command.AboutID,
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                Title = command.Title
            });
        }
    }
}
