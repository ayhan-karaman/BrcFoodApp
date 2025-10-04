using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrcFoodApp.WebUI.DTOs.WhyChooseBrcDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BrcFoodApp.WebUI.Controllers
{
    public class WhyChooseBrcController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhyChooseBrcController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WhyChooseBrcList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7291/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhyChooseBrcDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CreateWhyChooseBrc()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateWhyChooseBrc(CreateWhyChooseBrcDto createWhyChooseBrcDto)
        {
            var client = _httpClientFactory.CreateClient();
            var value = JsonConvert.SerializeObject(createWhyChooseBrcDto);
            var content = new StringContent(value, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7291/api/Services", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("WhyChooseBrcList");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateWhyChooseBrc(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7291/api/Services/GetServiceById?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateWhyChooseBrcDto>(jsonData);
              

                return View(value);
            }
            return RedirectToAction("WhyChooseBrcList");
        }

        

        [HttpPost]
        public async Task<IActionResult> UpdateWhyChooseBrc(UpdateWhyChooseBrcDto updateWhyChooseBrcDto)
        {
            var client = _httpClientFactory.CreateClient();
            var value = JsonConvert.SerializeObject(updateWhyChooseBrcDto);
            var content = new StringContent(value, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7291/api/Services", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("WhyChooseBrcList");
            }
            return View();
        }



        public async Task<IActionResult> DeleteWhyChooseBrc(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7291/api/Services?id={id}");
            return RedirectToAction("WhyChooseBrcList");

        }


        
    }
}