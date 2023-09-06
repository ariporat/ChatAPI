using ChatAPI.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace ChatAPI
{
	public class PrivateMessageHub : Hub
	{
		private readonly ChatDbContext _dbContext;

		public PrivateMessageHub(ChatDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		static ConcurrentDictionary<string, string> connectedUsers = new ConcurrentDictionary<string, string>();


		[HubMethodName("ConnectToUsersList")]
		public async Task ConnectToUsersList(string nickname)
		{
			try
			{
				var connectionId = Context.ConnectionId;

				connectedUsers.AddOrUpdate(nickname, connectionId, (key, oldValue) => connectionId);

				await Clients.All.SendAsync("connectedUsers", connectedUsers.ToList());
			}
			catch (Exception ex)
			{
				 ex.ToString();
			}
		}

	


		public async Task SendToIndividual(string connectionId, string message, string fromuser,string touser)
		{
			

			//var chatMessage = new ChatMessage
			//{
			//	ChatID = ChatIdGenerator.GenerateChatId(fromuser, touser),
			//   Sender = fromUser,
			//	Message = message,
			//	Date = DateTime.UtcNow // You can use UTC time for consistency
				
			//};
			await Clients.Client(connectionId).SendAsync("ReceiveMessage", message, fromuser);
			

		}
		
	}
}
//string test = Context.ConnectionId;

