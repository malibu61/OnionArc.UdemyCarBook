﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CarDetailDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarDescriptionByCarIdComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _CarDetailCarDescriptionByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;
			var client = _httpClientFactory.CreateClient();
			var resposenMessage = await client.GetAsync($"https://localhost:7274/api/CarDescription?id=" + id);
			if (resposenMessage.IsSuccessStatusCode)
			{
				var jsonData = await resposenMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultCarDescriptionByCarIdDto>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
