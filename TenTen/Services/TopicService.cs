using System.Text.Json;
using TenTenApp.Models;

namespace TenTenApp.Services;

public class TopicService : ITopicService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;
    private static List<Topic> _topics = new();

    public TopicService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        // 초기 더미 데이터 설정 (한 번만)
        if (!_topics.Any())
        {
            InitializeTopics();
        }
    }

    private void InitializeTopics()
    {
        _topics = new List<Topic>
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
    }

    public async Task<List<Topic>> GetTopicsAsync()
    {
        try
        {
            // API 호출 시뮬레이션
            await Task.Delay(500);
            
            // 메모리에 저장된 주제 목록 반환
            return new List<Topic>(_topics);
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
            
            // 새로운 ID 생성 (기존 ID 중 최대값 + 1)
            var newId = _topics.Any() ? _topics.Max(t => t.Id) + 1 : 1;
            
            var newTopic = new Topic
            {
                Id = newId,
                Subject = request.Subject,
                TopicDate = request.TopicDate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            // 메모리에 주제 추가
            _topics.Add(newTopic);

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
            
            var topic = _topics.FirstOrDefault(t => t.Id == id);
            if (topic != null)
            {
                topic.Subject = request.Subject;
                topic.TopicDate = request.TopicDate;
                topic.UpdatedAt = DateTime.Now;
                return true;
            }
            
            return false;
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
            
            var topic = _topics.FirstOrDefault(t => t.Id == id);
            if (topic != null)
            {
                _topics.Remove(topic);
                return true;
            }
            
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}