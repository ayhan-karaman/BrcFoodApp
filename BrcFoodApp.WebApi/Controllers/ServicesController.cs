using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public ServicesController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult ServicesList()
        {
            var values = _apiContext.Services.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _apiContext.Services.Add(service);
            var result = _apiContext.SaveChanges();
            if (result >= 1)
                return Ok("Hizmet başarıyla eklendi");
            return BadRequest("Hizmet eklenirken bir hata oluştu");
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _apiContext.Services.Update(service);
            _apiContext.SaveChanges();
            return Ok("Hizmet Güncelleme işlemi başarılı");
        }

        [HttpGet("GetServiceById")]
        public IActionResult GetServiceById(int id)
        {
            var value = _apiContext.Services.Find(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _apiContext.Services.Find(id);
            _apiContext.Services.Remove(value);
            _apiContext.SaveChanges();
            return Ok($"{value.Title} isimli hizmet silindi");
        }
    }
}