
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Dtos.ContactDtos;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public ContactsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult ContactsList()
        {
            var values = _apiContext.Contacts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto contactDto)
        {
            Contact contact = new Contact();
            contact.Email = contactDto.Email;
            contact.MapLocation = contactDto.MapLocation;
            contact.Address = contactDto.Address;
            contact.Phone = contactDto.Phone;
            contact.OpenHours = contactDto.OpenHours;
            _apiContext.Contacts.Add(contact);
            _apiContext.SaveChanges();
            return Ok("Kayıt işlemi başarılı.");
        }
    }
}