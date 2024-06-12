using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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

			channel.QueueDeclare(queue:"message-queue2",durable:false,exclusive:false,autoDelete:false,arguments:null);

			var messageContent="Hello RabbitMQ 3";

			var byteMessageContent=Encoding.UTF8.GetBytes(messageContent);

			channel.BasicPublish(exchange: "", routingKey: "message-queue2", basicProperties: null, byteMessageContent);

			return Ok("Message in queue.");
		}
		private static string _message;
		[HttpGet]
		public IActionResult GetMessage()
		{
			var connectionFactory=new ConnectionFactory()
			{
			HostName="localhost",
			UserName="guest",
			Password="guest"

			};
			var connection=connectionFactory.CreateConnection();
			var channel=connection.CreateModel();


			var consumer= new EventingBasicConsumer(channel);
			consumer.Received += (model, ea) =>
			{
				var byteMessage = ea.Body.ToArray();
				_message = Encoding.UTF8.GetString(byteMessage);

			};
			var result=channel.BasicConsume(queue:"message-queue2",autoAck:true,consumer:consumer);

			if(string.IsNullOrEmpty(_message))
			{
				return NoContent();
			}


			return Ok(_message);
		}
	}
}
