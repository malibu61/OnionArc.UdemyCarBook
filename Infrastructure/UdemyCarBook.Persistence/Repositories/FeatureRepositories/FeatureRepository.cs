using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.FeatureInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.FeatureRepositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly CarBookContext _context;

        public FeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetLastCreatedFeatureId()
        {
            var lastFeatureId = _context.Features.OrderByDescending(x => x.FeatureID).Select(x => x.FeatureID).Take(1).FirstOrDefault();

            return lastFeatureId;
        }
    }
}
