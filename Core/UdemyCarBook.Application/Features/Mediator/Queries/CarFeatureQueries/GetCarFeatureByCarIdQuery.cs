﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery : IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int CarID { get; set; }

        public GetCarFeatureByCarIdQuery(int carID)
        {
            CarID = carID;
        }
    }
}
