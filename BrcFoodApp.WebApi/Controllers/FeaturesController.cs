
using AutoMapper;
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Dtos.FeatureDtos;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _apiContext;

        public FeaturesController(IMapper mapper, ApiContext apiContext)
        {
            _mapper = mapper;
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult FeaturesList()
        {
            var values = _apiContext.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeature)
        {
            var value = _mapper.Map<Feature>(createFeature);
            _apiContext.Features.Add(value);
            _apiContext.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _apiContext.Features.Find(id);
            _apiContext.Features.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }


        [HttpGet("GetByFeatureId")]
        public IActionResult GetByFeatureId(int id)
        {
            var value = _apiContext.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeature)
        {
            var value = _mapper.Map<Feature>(updateFeature);
            _apiContext.Features.Update(value);
            _apiContext.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}