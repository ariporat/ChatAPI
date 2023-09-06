using Microsoft.EntityFrameworkCore;
using ChatAPI.Models; // Replace with the appropriate namespace for your models

public class ChatDbContext : DbContext
{
	public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
	{
	}
public DbSet<ChatMessage> ChatMessages { get; set; }


	public DbSet<ChatWindow> ChatWindows { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ChatMessage>()
			  .HasOne(cm => cm.ChatWindow)
			  .WithMany(x=>x.Messages)
				.HasForeignKey(cm => cm.ChatID);

		base.OnModelCreating(modelBuilder);
	}
}