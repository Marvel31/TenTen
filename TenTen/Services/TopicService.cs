using System.Text.Json;
using TenTenApp.Models;

namespace TenTenApp.Services;

public class TopicService : ITopicService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public TopicService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<Topic>> GetTopicsAsync()
    {
        try
        {
            // 실제 API가 없으므로 더미 데이터 반환
            await Task.Delay(500); // API 호출 시뮬레이션
            
            var topics = new List<Topic>
            {
                new Topic
                {
                    Id = 1,
                    Subject = "오늘 가장 기뻤던 순간",
                    TopicDate = DateTime.Today,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    UpdatedAt = DateTime.Now.AddDays(-1)
                },
                new Topic
                {
                    Id = 2,
                    Subject = "내일 가장 기대되는 일",
                    TopicDate = DateTime.Today.AddDays(1),
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now.AddDays(-2)
                },
                new Topic
                {
                    Id = 3,
                    Subject = "이번 주 감사했던 일",
                    TopicDate = DateTime.Today.AddDays(-1),
                    CreatedAt = DateTime.Now.AddDays(-3),
                    UpdatedAt = DateTime.Now.AddDays(-3)
                }
            };

            return topics;
        }
        catch (Exception)
        {
            return new List<Topic>();
        }
    }

    public async Task<Topic?> GetTopicAsync(int id)
    {
        var topics = await GetTopicsAsync();
        return topics.FirstOrDefault(t => t.Id == id);
    }

    public async Task<Topic> CreateTopicAsync(CreateTopicRequest request)
    {
        try
        {
            await Task.Delay(300); // API 호출 시뮬레이션
            
            var newTopic = new Topic
            {
                Id = DateTime.Now.Millisecond, // 임시 ID 생성
                Subject = request.Subject,
                TopicDate = request.TopicDate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return newTopic;
        }
        catch (Exception)
        {
            throw new InvalidOperationException("주제 생성 중 오류가 발생했습니다.");
        }
    }

    public async Task<bool> UpdateTopicAsync(int id, UpdateTopicRequest request)
    {
        try
        {
            await Task.Delay(300); // API 호출 시뮬레이션
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteTopicAsync(int id)
    {
        try
        {
            await Task.Delay(300); // API 호출 시뮬레이션
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}