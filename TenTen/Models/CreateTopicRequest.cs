using System.ComponentModel.DataAnnotations;

namespace TenTenApp.Models;

public class CreateTopicRequest
{
    [Required(ErrorMessage = "주제는 필수입니다.")]
    [StringLength(200, ErrorMessage = "주제는 200자를 초과할 수 없습니다.")]
    public string Subject { get; set; } = string.Empty;

    [Required(ErrorMessage = "날짜는 필수입니다.")]
    public DateTime TopicDate { get; set; }
}