namespace ChatAPI.Models
{
	public class ChatMessage
	{

		public int Id { get; set; }
		public int ChatID { get; set; }
		public string Sender { get; set; }
		public string Message { get; set; }
		public DateTime Date { get; set; }
		public ChatWindow ChatWindow { get; set; }
	}
}
