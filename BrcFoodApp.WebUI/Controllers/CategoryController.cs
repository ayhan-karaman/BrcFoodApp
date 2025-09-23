
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


        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7291/api/Categories/GetCategoryById?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(value);
            }
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var value = JsonConvert.SerializeObject(updateCategoryDto);
            var content = new StringContent(value, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7291/api/Categories", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("CategoryList");
            }
            return View();
        }


        
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7291/api/Categories?id={id}");
            return RedirectToAction("CategoryList");

        }

    }
}