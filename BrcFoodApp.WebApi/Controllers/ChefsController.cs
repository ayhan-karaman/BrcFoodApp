
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public ChefsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }


        [HttpGet]
        public IActionResult ChefsList()
        {
            var values = _apiContext.Chefs.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _apiContext.Chefs.Add(chef);
            _apiContext.SaveChanges();
            return Ok("Şef başarıyla sisteme eklendi.");
        }

        [HttpPost("AddRangeChef")]
        public IActionResult AddRangeChef(List<Chef> chefs)
        {
            _apiContext.Chefs.AddRange(chefs);
            _apiContext.SaveChanges();
            return Ok("Şefler başarıyla sisteme eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _apiContext.Chefs.Update(chef);
            _apiContext.SaveChanges();
            return Ok("Şef başarıyla sistemde güncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value = _apiContext.Chefs.Find(id);
            _apiContext.Chefs.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Şef sistemden silindi");
        }

        [HttpGet("GetChefById")]
        public IActionResult GetChefById(int id)
        {
            return Ok(_apiContext.Chefs.Find(id));
        }
    }
}