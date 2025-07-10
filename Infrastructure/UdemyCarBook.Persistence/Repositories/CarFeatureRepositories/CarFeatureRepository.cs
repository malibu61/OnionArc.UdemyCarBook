using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public void AssingCarFeatureAvailableToNewOne(int carId, int featureId, bool available)
        {
            _context.Add(new CarFeature()
            {
                Available = available,
                CarID = carId,
                FeatureID = featureId
            });
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToFalse(int carId, int featureId)
        {
            var values = _context.CarFeatures.Where(x => x.FeatureID == featureId && x.CarID == carId).FirstOrDefault();
            values.Available = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int carId, int featureId)
        {
            var values = _context.CarFeatures.Where(x => x.FeatureID == featureId && x.CarID == carId).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public List<CarFeature> GetCarFeaturesByCarID(int carId)
        {
            var values = _context.CarFeatures.Include(x => x.Feature).Include(x => x.Car).ThenInclude(x => x.Brand).Where(x => x.CarID == carId).ToList();
            return values;
        }
    }
}
