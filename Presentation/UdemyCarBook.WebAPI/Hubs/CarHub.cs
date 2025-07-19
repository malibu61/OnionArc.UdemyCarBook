
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.StatisticsDtos;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.WebAPI.Hubs
{
	public class CarHub : Hub
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CarHub(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task SendStatistic()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7274/api/Statistics/GetCarCount");

			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);

			await Clients.All.SendAsync("ReceiveCarCount", values?.carCount);
		}
	}
}
