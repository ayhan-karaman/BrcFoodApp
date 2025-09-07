
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrcEventsController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public BrcEventsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult BrcEventsList()
        {
            var values = _apiContext.BrcEvents.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBrcEvent(BrcEvent brcEvent)
        {
            _apiContext.BrcEvents.Add(brcEvent);
            var result = _apiContext.SaveChanges();
            if (result >= 1)
                return Ok("Etkinlik başarıyla eklendi");
            return BadRequest("Etkinlik eklenirken bir hata oluştu");
        }

        [HttpPut]
        public IActionResult UpdateBrcEvent(BrcEvent brcEvent)
        {
            _apiContext.BrcEvents.Update(brcEvent);
            _apiContext.SaveChanges();
            return Ok("Etkinlik Güncelleme işlemi başarılı");
        }

        [HttpGet("GetBrcEventById")]
        public IActionResult GetBrcEventById(int id)
        {
            var value = _apiContext.BrcEvents.Find(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteBrcEvent(int id)
        {
            var value = _apiContext.BrcEvents.Find(id);
            _apiContext.BrcEvents.Remove(value);
            _apiContext.SaveChanges();
            return Ok($"{value.Title} isimli etkinlik silindi");
        }
    }
}