using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticsDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region İstatistik1
            var responseMessage = await client.GetAsync("https://localhost:7274/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.carCount;
                ViewBag.v1 = v1;
            }
            #endregion

            #region İstatistik2
            var responseMessage2 = await client.GetAsync("https://localhost:7274/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int locationCountRandom = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = values2.locationCount;
                ViewBag.locationCountRandom = locationCountRandom;
            }
            #endregion

            #region İstatistik3
            var responseMessage3 = await client.GetAsync("https://localhost:7274/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int authorCountRandom = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.authorCount = values3.authorCount;
                ViewBag.authorCountRandom = authorCountRandom;
            }
            #endregion

            #region İstatistik4
            var responseMessage4 = await client.GetAsync("https://localhost:7274/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int blogCountRandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.blogCount = values4.blogCount;
                ViewBag.blogCountRandom = blogCountRandom;
            }
            #endregion

            #region İstatistik5
            var responseMessage5 = await client.GetAsync("https://localhost:7274/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int brandCountRandom = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.brandCount = values5.brandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }
            #endregion

            #region İstatistik6
            var responseMessage6 = await client.GetAsync("https://localhost:7274/api/Statistics/GetAverageRentingForADay");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int averageRentingForADayRandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.averageRentingForADay = values6.averageRentingForADay.ToString("0.00");
                ViewBag.averageRentingForADayRandom = averageRentingForADayRandom;
            }
            #endregion

            #region İstatistik7
            var responseMessage7 = await client.GetAsync("https://localhost:7274/api/Statistics/GetAverageRentingForAWeek");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int averageRentingForAWeekRandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.averageRentingForAWeek = values7.averageRentingForAWeek.ToString("0.00");
                ViewBag.averageRentingForAWeekRandom = averageRentingForAWeekRandom;
            }
            #endregion

            #region İstatistik8
            var responseMessage8 = await client.GetAsync("https://localhost:7274/api/Statistics/GetAverageRentingForAMonth");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int averageRentingForAMonthRandom = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.averageRentingForAMonth = values8.averageRentingForAMonth.ToString("0.00");
                ViewBag.averageRentingForAMonthRandom = averageRentingForAMonthRandom;
            }
            #endregion

            #region İstatistik9
            var responseMessage9 = await client.GetAsync("https://localhost:7274/api/Statistics/GetCarCountWithAutomaticTransmission");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int carCountWithAutomaticTransmissionRandom = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.carCountWithAutomaticTransmission = values9.carCountWithAutomaticTransmission;
                ViewBag.carCountWithAutomaticTransmissionRandom = carCountWithAutomaticTransmissionRandom;
            }
            #endregion

            #region İstatistik10
            var responseMessage10 = await client.GetAsync("https://localhost:7274/api/Statistics/GetCarCountWithManuelTransmission");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int carCountWithManuelTransmissionRandom = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.carCountWithManuelTransmission = values10.carCountWithManuelTransmission;
                ViewBag.carCountWithManuelTransmissionRandom = carCountWithManuelTransmissionRandom;
            }
            #endregion

            #region İstatistik11
            var responseMessage11 = await client.GetAsync("https://localhost:7274/api/Statistics/GetBlogTitleHavingMostComment");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int blogTitleHavingMostCommentRandom = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.blogTitleHavingMostComment = values11.blogTitleHavingMostComment;
                ViewBag.blogTitleHavingMostCommentRandom = blogTitleHavingMostCommentRandom;
            }
            #endregion

            #region İstatistik12
            var responseMessage12 = await client.GetAsync("https://localhost:7274/api/Statistics/GetDieselCarCount");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int dieselCarCountRandom = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.dieselCarCount = values12.dieselCarCount;
                ViewBag.dieselCarCountRandom = dieselCarCountRandom;
            }
            #endregion

            #region İstatistik13
            var responseMessage13 = await client.GetAsync("https://localhost:7274/api/Statistics/GetGasolineCarCount");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int gasolineCarCountRandom = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.gasolineCarCount = values13.gasolineCarCount;
                ViewBag.gasolineCarCountRandom = gasolineCarCountRandom;
            }
            #endregion

            #region İstatistik14
            var responseMessage14 = await client.GetAsync("https://localhost:7274/api/Statistics/GetBrandNameHavingMostCar");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int brandNameHavingMostCarRandom = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.brandNameHavingMostCar = values14.brandNameHavingMostCar;
                ViewBag.brandNameHavingMostCarCar = brandNameHavingMostCarRandom;
            }
            #endregion

            #region İstatistik15
            var responseMessage15 = await client.GetAsync("https://localhost:7274/api/Statistics/GetMostExpensiveCar");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int mostExpensiveCarRandom = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.mostExpensiveCar = values15.mostExpensiveCar;
                ViewBag.mostExpensiveCarRandom = mostExpensiveCarRandom;
            }
            #endregion

            #region İstatistik16
            var responseMessage16 = await client.GetAsync("https://localhost:7274/api/Statistics/GetTheCheapestCar");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int theCheapestCarRandom = random.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.theCheapestCar = values16.theCheapestCar;
                ViewBag.theCheapestCarRandom = theCheapestCarRandom;
            }
            #endregion

            return View();
        }
    }
}
