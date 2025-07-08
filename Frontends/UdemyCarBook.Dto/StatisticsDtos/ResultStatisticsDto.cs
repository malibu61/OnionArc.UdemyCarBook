using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int carCount { get; set; }
        public int locationCount { get; set; }
        public int authorCount { get; set; }
        public int blogCount { get; set; }
        public int brandCount { get; set; }
        //[JsonProperty("avgPriceForDaily")]
        public decimal averageRentingForADay { get; set; }
        public decimal averageRentingForAWeek { get; set; }
        public decimal averageRentingForAMonth { get; set; }
        public int carCountWithAutomaticTransmission { get; set; }
        public int carCountWithManuelTransmission { get; set; }
        public int dieselCarCount { get; set; }
        public int gasolineCarCount { get; set; }
        public string brandNameHavingMostCar { get; set; }
        public string blogTitleHavingMostComment { get; set; }
        public string brandNameByMostCar { get; set; }
        public string mostExpensiveCar { get; set; }
        public string theCheapestCar { get; set; }
        


    }
}
