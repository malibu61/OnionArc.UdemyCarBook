using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.LocationInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.LocationRepositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly CarBookContext _context;

        public LocationRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
