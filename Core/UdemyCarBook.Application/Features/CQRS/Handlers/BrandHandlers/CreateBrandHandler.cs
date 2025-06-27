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
    public class CreateBrandHandler
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBrandCommand command)
        {
            await _repository.CreateAsync(new Brand()
            {
                Name = command.Name
            });
        }
    }
}
