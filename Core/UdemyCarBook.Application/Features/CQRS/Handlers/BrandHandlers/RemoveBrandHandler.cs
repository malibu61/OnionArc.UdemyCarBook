using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommand;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandHandler
    {
        private readonly IRepository<Brand> _repository;

        public RemoveBrandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBrandCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
