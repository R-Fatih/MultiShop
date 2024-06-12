using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		[HttpPost]
		public IActionResult CreateMessage()
		{
			var connectionFactory=new ConnectionFactory() { 
			HostName="localhost",
			UserName="guest",
			Password="guest"

			};
			var connection=connectionFactory.CreateConnection();
			var channel=connection.CreateModel();

			channel.QueueDeclare(queue:"message-queue",durable:false,exclusive:false,autoDelete:false,arguments:null);

			var messageContent="Hello RabbitMQ";

			var byteMessageContent=Encoding.UTF8.GetBytes(messageContent);

			channel.BasicPublish(exchange: "", routingKey: "message-queue", basicProperties: null, byteMessageContent);

			return Ok("Message in queue.");
		}
	}
}
