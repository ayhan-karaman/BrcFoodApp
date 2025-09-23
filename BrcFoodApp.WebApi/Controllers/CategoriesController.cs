using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Dtos.CategoryDtos;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _apiContext;
        private readonly IMapper _mapper;

        public CategoriesController(ApiContext apiContext, IMapper mapper)
        {
            _apiContext = apiContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoriesList()
        {
            var values = _apiContext.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            _apiContext.Categories.Add(value);
            var result = _apiContext.SaveChanges();
            if (result >= 1)
                return Ok("Kategori başarıyla eklendi");
            return BadRequest("Kategori eklenirken bir hata oluştu");
        }
        [HttpPost("AddRangeCategory")]
        public IActionResult AddRangeCategory(List<CreateCategoryDto> categories)
        {
            var values = _mapper.Map<List<Category>>(categories);
            _apiContext.Categories.AddRange(values);
            var result = _apiContext.SaveChanges();
            if (result >= 1)
                return Ok("Kategoriler başarıyla eklendi");
            return BadRequest("Kategoriler eklenirken bir hata oluştu");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
             var value = _mapper.Map<Category>(updateCategoryDto);
            _apiContext.Categories.Update(value);
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
            _apiContext.Categories.Remove(value!);
            _apiContext.SaveChanges();
            return Ok($"{value!.CategoryName} isimli kategori silindi");
        }
    }
}