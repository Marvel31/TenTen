using System.ComponentModel.DataAnnotations;

namespace TenTenApp.Models;

public class CreateTenTenRequest
{
    [Required(ErrorMessage = "내용은 필수입니다.")]
    [StringLength(2000, ErrorMessage = "내용은 2000자를 초과할 수 없습니다.")]
    [MinLength(10, ErrorMessage = "내용은 최소 10자 이상이어야 합니다.")]
    public string Content { get; set; } = string.Empty;

    [Required(ErrorMessage = "주제 ID는 필수입니다.")]
    public int TopicId { get; set; }
}