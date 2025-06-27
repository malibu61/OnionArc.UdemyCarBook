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
    public class UpdateContactHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var values = await _repository.GetByIdAsync(command.ContactID);
            values.Email = command.Email;
            values.SendDate = command.SendDate;
            values.Subject = command.Subject;
            values.Message = command.Message;
            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
