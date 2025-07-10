using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.CarFeatureDtos;
using UdemyCarBook.Dto.FeatureDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7274/api/CarFeature?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);

                if (values.Count == 0)
                {
                    TempData["PopupMessage"] = "Once Ozellik atamaniz gerek!";
                    return RedirectToAction("Index", "AdminCar");
                }

                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {

            var client = _httpClientFactory.CreateClient();

            foreach (var item in resultCarFeatureByCarIdDto)
            {
                // JSON body hazırlanıyor
                var command = new
                {
                    featureID = item.FeatureID,
                    carID = item.CarID
                };

                var json = JsonConvert.SerializeObject(command);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Hangi URL'ye gidecek
                string url = item.Available
                    ? "https://localhost:7274/api/CarFeature/ChangeCarFeatureAvailableToTrue"
                    : "https://localhost:7274/api/CarFeature/ChangeCarFeatureAvailableToFalse";

                // POST isteği at
                await client.PostAsync(url, content);
            }

            return RedirectToAction("Index", "AdminCar");
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {
            TempData["CarId"] = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7274/api/Feature");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);




                var responseMessage2 = await client.GetAsync("https://localhost:7274/api/CarFeature?id=" + id);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData2);

                    if (values2.Count != 0)
                    {
                        TempData["PopupMessage"] = "Özellik zaten atanmış güncelleme yapınız!";
                        return RedirectToAction("Index", "AdminCar");
                    }

                }

                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureByCarId(List<AssignFeatureToACarDto> assignFeatureToACarDtos)
        {
            var client = _httpClientFactory.CreateClient();

            foreach (var item in assignFeatureToACarDtos)
            {
                // JSON body hazırlanıyor
                var command = new
                {
                    featureID = item.FeatureID,
                    carID = TempData["CarId"],
                    available = item.Available
                };

                var json = JsonConvert.SerializeObject(command);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Hangi URL'ye gidecek
                string url = "https://localhost:7274/api/CarFeature/AssingCarFeatureAvailableToNewOne"
                    ;

                // POST isteği at
                await client.PostAsync(url, content);
            }

            return RedirectToAction("Index", "AdminCar");
        }
    }
}
