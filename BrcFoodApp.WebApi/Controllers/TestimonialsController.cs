using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public TestimonialsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult TestimonialsList()
        {
            var values = _apiContext.Testimonials.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _apiContext.Testimonials.Add(testimonial);
            var result = _apiContext.SaveChanges();
            if (result >= 1)
                return Ok("Referans başarıyla eklendi");
            return BadRequest("Referans eklenirken bir hata oluştu");
        }
        [HttpPost("CreateRangeTestimonial")]
        public IActionResult CreateRangeTestimonial(List<Testimonial> testimonials)
        {
            _apiContext.Testimonials.AddRange(testimonials);
            var result = _apiContext.SaveChanges();
            if (result >= 1)
                return Ok("Referanslar başarıyla eklendi");
            return BadRequest("Referanslar eklenirken bir hata oluştu");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _apiContext.Testimonials.Update(testimonial);
            _apiContext.SaveChanges();
            return Ok("Referans Güncelleme işlemi başarılı");
        }

        [HttpGet("GetTestimonialById")]
        public IActionResult GetTestimonialById(int id)
        {
            var value = _apiContext.Testimonials.Find(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _apiContext.Testimonials.Find(id);
            _apiContext.Testimonials.Remove(value);
            _apiContext.SaveChanges();
            return Ok($"{value.Title} isimli referans silindi");
        }
    }
}