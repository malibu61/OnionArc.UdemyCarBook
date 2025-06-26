using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BannerID);
            values.VideoDescription = command.VideoDescription;
            values.Title = command.Title;
            values.Description = command.Description;
            values.BannerID = command.BannerID;
            values.VideoUrl = command.VideoUrl;
            await _repository.UpdateAsync(values);

            //await _repository.UpdateAsync(new Banner()
            //{
            //    BannerID = command.BannerID,
            //    Description = command.Description,
            //    Title = command.Title,
            //    VideoDescription = command.VideoDescription,
            //    VideoUrl = command.VideoUrl
            //}); // bu çalışmayabilir
        }
    }
}
