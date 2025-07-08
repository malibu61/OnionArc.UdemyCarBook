using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int BlogCount();
        int BrandCount();
        int CarCountWithAutomaticTransmission();
        int CarCountWithManuelTransmission();
        string BrandNameHavingMostCar();
        string BlogTitleHavingMostComment();
        decimal AverageRentingForADay();
        decimal AverageRentingForAWeek();
        decimal AverageRentingForAMonth();
        string MostExpensiveCar();
        string TheCheapestCar();
        int GasolineCarCount();
        int DieselCarCount();
    }
}
