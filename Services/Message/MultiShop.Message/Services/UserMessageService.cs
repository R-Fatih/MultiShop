using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _context;
        private readonly IMapper _mapper;
        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var value=_mapper.Map<UserMessage>(createMessageDto);
            await _context.UserMessages.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int MessageId)
        {
            var values=await _context.UserMessages.FindAsync(MessageId);
            _context.UserMessages.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessagesAsync()
        {
            var values=await _context.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessage(string receiverId)
        {
            var values = await _context.UserMessages.Where(x => x.ReceiverId == receiverId).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<ResultMessageDto> GetMessageByIdAsync(int messageId)
        {
            var values=await _context.UserMessages.FindAsync(messageId);
            return _mapper.Map<ResultMessageDto>(values);
        }

		public async Task<int> GetMessageCountAsync()
		{
            int count =await _context.UserMessages.CountAsync();
            return count;
		}

        public async Task<int> GetMessageCountByReseriverIdAsync(string receiverId)
        {
            var values=await _context.UserMessages.Where(x => x.ReceiverId == receiverId).CountAsync();
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendMessage(string senderId)
        {
            var values = await _context.UserMessages.Where(x => x.SenderId == senderId).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var value=_mapper.Map<UserMessage>(updateMessageDto);
            _context.UserMessages.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}
