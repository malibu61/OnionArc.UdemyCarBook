﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            //var values = await _repository.GetByIdAsync(request.TestimonialID);
            //values.Title = request.Title;
            //values.Comment = request.Comment;
            //values.Name = request.Name;
            //values.ImageUrl = request.ImageUrl;
            //await _repository.UpdateAsync(values);

            await _repository.UpdateAsync(new Testimonial()
            {
                TestimonialID = request.TestimonialID,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                Comment = request.Comment,
                Title = request.Title
            });
        }
    }
}
