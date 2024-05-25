using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            return Ok(await _userMessageService.GetAllMessagesAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Message sended.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            return Ok(await _userMessageService.GetMessageByIdAsync(id));
        }
        [HttpGet("GetInbox")]
        public async Task<IActionResult> GetInboxMessage(string receiverId)
        {
            return Ok(await _userMessageService.GetInboxMessage(receiverId));
        }
        [HttpGet("GetSendbox")]
        public async Task<IActionResult> GetSendMessage(string senderId)
        {
            return Ok(await _userMessageService.GetSendMessage(senderId));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Message updated.");
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Message deleted.");
        }
        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetMessageCount()
        {
			return Ok(await _userMessageService.GetMessageCountAsync());
		}
        [HttpGet("GetMessageCountByReceiverId")]
        public async Task<IActionResult> GetMessageCountByReseriverIdAsync(string receiverId)
        {
            return Ok(await _userMessageService.GetMessageCountByReseriverIdAsync(receiverId));
        }
    }
}
