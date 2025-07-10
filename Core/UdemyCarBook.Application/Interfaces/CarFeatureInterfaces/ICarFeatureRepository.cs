using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeaturesByCarID(int carId);
        void ChangeCarFeatureAvailableToTrue(int carId, int carFeatureId);
        void ChangeCarFeatureAvailableToFalse(int carId, int carFeatureId);
        void AssingCarFeatureAvailableToNewOne(int carId, int carFeatureId,bool available);
    }
}
