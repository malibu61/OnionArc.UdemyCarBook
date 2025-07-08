using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public decimal AverageRentingForADay()
        {
            var values = _context.CarPricings.Where(x => x.PricingID == 2).Average(x => x.Amount);
            return values;
        }

        public decimal AverageRentingForAMonth()
        {
            var values = _context.CarPricings.Where(x => x.PricingID == 4).Average(x => x.Amount);
            return values;
        }

        public decimal AverageRentingForAWeek()
        {
            var values = _context.CarPricings.Where(x => x.PricingID == 3).Average(x => x.Amount);
            return values;
        }

        public int BlogCount()
        {
            var values = _context.Blogs.Count();
            return values;
        }

        public string BlogTitleHavingMostComment()
        {
            var blogTitle = _context.Comments
                                   .GroupBy(c => c.Blog.Title)
                                   .OrderByDescending(g => g.Count())
                                   .Select(g => g.Key)
                                   .FirstOrDefault();

            return blogTitle ?? "Yorum bulunamadı";

        }

        public int BrandCount()
        {
            var values = _context.Brands.Count();
            return values;
        }

        public string BrandNameHavingMostCar()
        {
            var brandName = _context.Cars
                                    .GroupBy(c => c.Brand.Name)
                                    .OrderByDescending(g => g.Count())
                                    .Select(g => g.Key)
                                    .FirstOrDefault();

            return brandName ?? "Araç Markası Bulunamadı";
        }

        public int CarCountWithAutomaticTransmission()
        {
            var values = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return values;
        }

        public int CarCountWithManuelTransmission()
        {
            var values = _context.Cars.Where(x => x.Transmission == "Manuel").Count();
            return values;
        }

        public int DieselCarCount()
        {
            var values = _context.Cars.Count(x => x.Fuel == "Dizel");
            return values;
        }

        public int GasolineCarCount()
        {
            var values = _context.Cars.Count(x => x.Fuel == "Benzin");
            return values;
        }

        public string MostExpensiveCar()
        {
            var values1 = _context.CarPricings.OrderByDescending(x => x.Amount).Take(1).Select(x => x.CarID).FirstOrDefault();
            var values2 = _context.Cars.Where(x => x.CarID == values1).Select(x => x.Brand.Name + " " + x.Model).FirstOrDefault();
            return values2.ToString();
        }

        public string TheCheapestCar()
        {
            var values1 = _context.CarPricings.OrderBy(x => x.Amount).Take(1).Select(x => x.CarID).FirstOrDefault();
            var values2 = _context.CarPricings.Where(x => x.CarID == values1).Select(x => x.Amount).FirstOrDefault();
            var values3 = _context.Cars.Where(x => x.CarID == values1).Select(x => x.Brand.Name + " " + x.Model + ": " + values2.ToString()).FirstOrDefault();
            return values3.ToString();
        }
    }
}
