﻿using MultiShop.DtoLayer.MessageDtos;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Services.MessageServices
{
	public interface IMessageService
	{
		//Task<List<ResultMessageDto>> GetAllMessagesAsync();
		Task<List<ResultInboxMessageDto>> GetInboxMessage(string receiverId);
		Task<List<ResultSendboxMessageDto>> GetSendboxMessage(string senderId);
		Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int MessageId);
        //Task<ResultMessageDto> GetMessageByIdAsync(int messageId);
        Task<int> GetMessageCountAsync();
        Task<int> GetMessageCountByReseriverIdAsync(string receiverId);
    }
}
