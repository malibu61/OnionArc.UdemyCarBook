using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
