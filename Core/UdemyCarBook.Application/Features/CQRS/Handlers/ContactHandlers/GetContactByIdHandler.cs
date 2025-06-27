using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;
using UdemyCarBook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                SendDate = values.SendDate,
                ContactID = values.ContactID,
                Email = values.Email,
                Message = values.Message,
                Name = values.Name,
                Subject = values.Subject
            };
        }
    }
}
