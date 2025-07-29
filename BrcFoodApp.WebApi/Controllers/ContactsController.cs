
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

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _apiContext.Contacts.Find(id);
            _apiContext.Contacts.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetByContactId")]
        public IActionResult GetByContactId(int id)
        {
            var value = _apiContext.Contacts.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContact)
        {
            Contact contact = new Contact();
            contact.Email = updateContact.Email;
            contact.Address = updateContact.Address;
            contact.Phone = updateContact.Phone;
            contact.MapLocation = updateContact.MapLocation;
            contact.OpenHours = updateContact.OpenHours;
            _apiContext.Contacts.Update(contact);
            _apiContext.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}