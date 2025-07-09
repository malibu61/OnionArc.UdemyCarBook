using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarsWPricingAndBrandWithTimePeriodQueryResult
    {
        public int CarId { get; set; }
        public int CarPricingId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Amount { get; set; }
        public decimal TimePeriodDaily { get; set; }
        public decimal TimePeriodMonthly { get; set; }
        public decimal TimePeriodWeekly { get; set; }
    }
}
