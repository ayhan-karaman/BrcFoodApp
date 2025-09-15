
using AutoMapper;
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Dtos.NotificationDtos;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _apiContext;

        public NotificationsController(IMapper mapper, ApiContext apiContext)
        {
            _mapper = mapper;
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult NotificationsList()
        {
            var values = _apiContext.Notifications.ToList();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotification)
        {
            var value = _mapper.Map<Notification>(createNotification);
            _apiContext.Notifications.Add(value);
            _apiContext.SaveChanges();
            return Ok("Bildirim ekleme işlemi başarılı");
        }
        [HttpPost("CreateNotificationAddRange")]
        public IActionResult CreateNotificationAddRange(List<CreateNotificationDto> createNotifications)
        {
            var values = _mapper.Map<List<Notification>>(createNotifications);
            _apiContext.Notifications.AddRange(values);
            _apiContext.SaveChanges();
            return Ok("Bildirimler başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _apiContext.Notifications.Find(id);
            _apiContext.Notifications.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }


        [HttpGet("GetByNotificationId")]
        public IActionResult GetByNotificationId(int id)
        {
            var value = _apiContext.Notifications.Find(id);
            return Ok(_mapper.Map<GetByIdNotificationDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotification)
        {
            var value = _mapper.Map<Notification>(updateNotification);
            _apiContext.Notifications.Update(value);
            _apiContext.SaveChanges();
            return Ok("Bildirim güncelleme işlemi başarılı");
        }
    }
}