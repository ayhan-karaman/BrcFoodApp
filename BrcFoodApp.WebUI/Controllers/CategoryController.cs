
using System.Text;
using BrcFoodApp.WebUI.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BrcFoodApp.WebUI.Controllers
{

    public class CategoryController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7291/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var value = JsonConvert.SerializeObject(createCategoryDto);
            var content = new StringContent(value, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7291/api/Categories", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("CategoryList");
            }
            return View();
        }

    }
}