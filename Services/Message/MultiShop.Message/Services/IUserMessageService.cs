using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessagesAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessage(string receiverId);
        Task<List<ResultSendboxMessageDto>> GetSendMessage(string senderId);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int MessageId);
        Task<ResultMessageDto> GetMessageByIdAsync(int messageId);
        Task<int> GetMessageCountAsync();
    }
}
