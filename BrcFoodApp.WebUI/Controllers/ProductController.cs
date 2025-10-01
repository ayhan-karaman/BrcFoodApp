using System.Text;
using BrcFoodApp.WebUI.DTOs.CategoryDtos;
using BrcFoodApp.WebUI.DTOs.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BrcFoodApp.WebUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7291/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            await ViewBagAppenedCategories();

            return View();

        }



        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var value = JsonConvert.SerializeObject(createProductDto);
            var content = new StringContent(value, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7291/api/Products/CreateProductWithCategory", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("ProductList");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7291/api/Products/GetByProductId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                await ViewBagAppenedCategories();

                return View(value);
            }
            return RedirectToAction("ProductList");
        }

        

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var value = JsonConvert.SerializeObject(updateProductDto);
            var content = new StringContent(value, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7291/api/Products", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("ProductList");
            }
            return View();
        }



        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7291/api/Products?id={id}");
            return RedirectToAction("ProductList");

        }


        private async Task ViewBagAppenedCategories()
        {
            var client = _httpClientFactory.CreateClient();
            var categoryResponseMessage = await client.GetAsync("https://localhost:7291/api/Categories");
            var categoryJsonData = await categoryResponseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJsonData);
            ViewBag.Categories = values!.Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            }).ToList();
        }
    }
}