namespace TenTenApp.Models;

public class Topic
{
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public DateTime TopicDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}