
using AutoMapper;
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Dtos.MessageDtos;
using BrcFoodApp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _apiContext;

        public MessagesController(IMapper mapper, ApiContext apiContext)
        {
            _mapper = mapper;
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult MessagesList()
        {
            var values = _mapper.Map<List<ResultMessageDto>>(_apiContext.Messages.ToList());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessage)
        {
            var value = _mapper.Map<Message>(createMessage);
            _apiContext.Messages.Add(value);
            _apiContext.SaveChanges();
            return Ok("Mesaj ekleme işlemi başarılı");
        }
        [HttpPost("CreateRangeMessage")]
        public IActionResult CreateRangeMessage(List<CreateMessageDto> createMessages)
        {
            var values = _mapper.Map<List<Message>>(createMessages);
            _apiContext.Messages.AddRange(values);
            _apiContext.SaveChanges();
            return Ok("Mesajların ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _apiContext.Messages.Find(id);
            _apiContext.Messages.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Mesaj başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessage)
        {
            var value = _mapper.Map<Message>(updateMessage);
            _apiContext.Messages.Update(value);
            _apiContext.SaveChanges();
            return Ok("Mesaj güncellendi");
        }

        [HttpGet("GetByMessageId")]
        public IActionResult GetByMessageId(int id)
        {
            var value = _mapper.Map<GetByIdMessageDto>(_apiContext.Messages.Find(id));
            return Ok(value);
        }

        [HttpGet("GetMessageByIsReadFalse")]
        public IActionResult GetMessageByIsReadFalse()
        {
            var values = _mapper.Map<List<ResultMessageDto>>(_apiContext.Messages.Where(x => x.IsRead.Equals(false)));
            return Ok(values);
        }
    }
}