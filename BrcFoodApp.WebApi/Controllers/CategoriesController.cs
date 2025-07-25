using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public CategoriesController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult CategoriesList()
        {
            var values = _apiContext.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _apiContext.Categories.Add(category);
            var result = _apiContext.SaveChanges();
            if (result >= 1)
                return Ok("Kategori başarıyla eklendi");
            return BadRequest("Kategori eklenirken bir hata oluştu");
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _apiContext.Categories.Update(category);
            _apiContext.SaveChanges();
            return Ok("Kategori Güncelleme işlemi başarılı");
        }

        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            var value = _apiContext.Categories.Find(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _apiContext.Categories.Find(id);
            _apiContext.Categories.Remove(value);
            _apiContext.SaveChanges();
            return Ok($"{value.CategoryName} isimli kategori silindi");
        }
    }
}