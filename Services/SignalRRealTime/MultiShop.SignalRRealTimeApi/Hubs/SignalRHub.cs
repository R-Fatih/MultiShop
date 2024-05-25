using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ISignalRMessageService _signalRSMessagService;
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRMessageService signalRMessageService, ISignalRCommentService signalRCommentService)
        {
            _signalRSMessagService = signalRMessageService;
            _signalRCommentService = signalRCommentService;
        }
        public async Task SendStatistics()
        {
            var totalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveTotalCommentCount", totalCommentCount);

            //var messageCount = await _signalRSMessagService.GetMessageCountByReseriverIdAsync(Context.ConnectionId);
            //await Clients.All.SendAsync("ReceiveMessageCount", messageCount);
        }
    }
}
