namespace TenTen.Models;

public class TenTenEntry
{
    public int Id { get; set; }
    public int TopicId { get; set; }
    public string TopicSubject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public bool IsReadByPartner { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
