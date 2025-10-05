using TenTenApp.Models;

namespace TenTenApp.Services;

public interface ITenTenService
{
    Task<List<TenTenEntry>> GetTenTensAsync();
    Task<List<TenTenEntry>> GetTenTensByTopicAsync(int topicId);
    Task<TenTenEntry?> GetTenTenAsync(int id);
    Task<TenTenEntry> CreateTenTenAsync(CreateTenTenRequest request);
    Task<bool> UpdateTenTenAsync(int id, UpdateTenTenRequest request);
    Task<bool> DeleteTenTenAsync(int id);
    Task<bool> MarkAsReadAsync(int id);
}