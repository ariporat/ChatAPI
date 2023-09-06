namespace ChatAPI.Models
{
	public class ChatWindow
	{
		public int Id { get; set; }
		public string user1 { get; set; }
		public string user2 { get; set; }
		public ICollection<ChatMessage> Messages { get; set; }
	}
}
