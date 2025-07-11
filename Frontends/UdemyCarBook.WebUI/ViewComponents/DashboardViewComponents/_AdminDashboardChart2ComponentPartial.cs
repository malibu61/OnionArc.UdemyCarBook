using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.CarDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardChart2ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardChart2ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7274/api/Car/CarListWBrand");

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<ResultCarBrandChartDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarBrandChartDto>>(json);

            var grouped = values
                .GroupBy(x => x.BrandName)
                .Select(g => new ResultCarBrandChartDto
                {
                    BrandName = g.Key,
                    Count = g.Count()
                }).ToList();

            return View(grouped);
        }
    }
}
