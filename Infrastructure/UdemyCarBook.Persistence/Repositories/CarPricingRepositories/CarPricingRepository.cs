using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.PricingInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarsWithPricing()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).Where(x => x.PricingID == 2).ToList();
            return values;
        }

        public List<CarPricing> GetCarsWithPricingWTimePeriod()
        {
            //var values = _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).ToList();
            //return values;
            var values = _context.CarPricings
                                            .Include(x => x.Car)
                                            .ThenInclude(x => x.Brand)
                                            .AsEnumerable() // LINQ to Objects'a geçiyoruz
                                            .GroupBy(x => x.CarID)
                                            .Select(g => g.First()) // Her araç için sadece ilk fiyat kaydını al
                                            .ToList();

            return values;
        }
    }
}
