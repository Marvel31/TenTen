using TenTenApp.Models;

namespace TenTenApp.Services;

public interface ITopicService
{
    Task<List<Topic>> GetTopicsAsync();
    Task<Topic?> GetTopicAsync(int id);
    Task<Topic> CreateTopicAsync(CreateTopicRequest request);
    Task<bool> UpdateTopicAsync(int id, UpdateTopicRequest request);
    Task<bool> DeleteTopicAsync(int id);
}