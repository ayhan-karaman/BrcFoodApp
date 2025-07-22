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

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _apiContext.Categories.Add(category);
            var result = _apiContext.SaveChanges();
            if (result >= 1)
                return Ok("Kategori başarıyla eklendi");
            return BadRequest("Kategori eklenirken bir hata oluştu");
        }
    }
}