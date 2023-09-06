using System.Security.Cryptography;
using System.Text;

namespace ChatAPI.Models
{
	public class ChatIdGenerator
	{

		public static int GenerateChatId(string userId1, string userId2)
		{
			// Sort user IDs to ensure consistency
			string[] sortedUserIds = { userId1, userId2 };
			Array.Sort(sortedUserIds);

			// Concatenate sorted user IDs
			string concatenatedIds = string.Join("_", sortedUserIds);

			
			int hash = 5381; // Initial hash value

			foreach (char c in concatenatedIds)
			{
				hash = ((hash << 5) + hash) + c;
			}

			return Math.Abs(hash); ;
		}
	}
}
