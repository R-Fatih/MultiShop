using MultiShop.DtoLayer.MessageDtos;
using NuGet.Protocol.Plugins;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.MessageServices
{
	public class MessageService : IMessageService
	{
		private readonly HttpClient _httpClient;

		public MessageService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public Task CreateMessageAsync(CreateMessageDto createMessageDto)
		{
			throw new NotImplementedException();
		}

		public async Task<List<ResultInboxMessageDto>> GetInboxMessage(string receiverId)
		{
			return await _httpClient.GetFromJsonAsync<List<ResultInboxMessageDto>>($"UserMessage/GetInbox?receiverId={receiverId}");
		}

        public async Task<int> GetMessageCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>($"UserMessage/GetTotalMessageCount");
        }

        public async Task<int> GetMessageCountByReseriverIdAsync(string receiverId)
        {
            return await _httpClient.GetFromJsonAsync<int>($"UserMessage/GetMessageCountByReceiverId?receiverId={receiverId}");

        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessage(string senderId)
		{
			return await _httpClient.GetFromJsonAsync<List<ResultSendboxMessageDto>>($"UserMessage/GetSendbox?senderId={senderId}");
		}
	}
}
