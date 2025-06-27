using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryHandler
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handler(RemoveCategoryCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
