

using BrcFoodApp.WebUI.DTOs.BrcEventDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BrcFoodApp.WebUI.ViewComponents
{
    public class _BrcEventDefaultComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BrcEventDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7291/api/BrcEvents");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrcEventDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}