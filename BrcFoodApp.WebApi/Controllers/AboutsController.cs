
using AutoMapper;
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Dtos.AboutDtos;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutsController : ControllerBase
    {
        private readonly ApiContext _apiContext;
        private readonly IMapper _mapper;

        public AboutsController(ApiContext apiContext, IMapper mapper)
        {
            _apiContext = apiContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutsList()
        {
            var values = _apiContext.Abouts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _apiContext.Abouts.Add(value);
            var result = _apiContext.SaveChanges();
            if (result >= 1)
                return Ok("Hakkımızda başarıyla eklendi");
            return BadRequest("Hakkımızda eklenirken bir hata oluştu");
        }
        

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
             var value = _mapper.Map<About>(updateAboutDto);
            _apiContext.Abouts.Update(value);
            _apiContext.SaveChanges();
            return Ok("Hakkımızda Güncelleme işlemi başarılı");
        }

        [HttpGet("GetAboutById")]
        public IActionResult GetAboutById(int id)
        {
            var value = _apiContext.Abouts.Find(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _apiContext.Abouts.Find(id);
            _apiContext.Abouts.Remove(value!);
            _apiContext.SaveChanges();
            return Ok($"{value!.Title} isimli hakkımızda silindi");
        }
    }
}