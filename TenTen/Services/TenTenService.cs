using System.Text.Json;
using TenTenApp.Models;

namespace TenTenApp.Services;

public class TenTenService : ITenTenService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public TenTenService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<TenTenEntry>> GetTenTensAsync()
    {
        try
        {
            // 실제 API가 없으므로 더미 데이터 반환
            await Task.Delay(500); // API 호출 시뮬레이션
            
            var tenTens = new List<TenTenEntry>
            {
                new TenTenEntry
                {
                    Id = 1,
                    TopicId = 1,
                    TopicSubject = "오늘 가장 기뻤던 순간",
                    Content = "오늘 아침에 커피를 마시면서 창밖을 바라보니 새가 지저귀고 있었어요. 그 순간 마음이 평화로워지면서 하루가 좋아질 것 같다는 생각이 들었습니다.",
                    UserId = 1,
                    IsReadByPartner = false,
                    CreatedAt = DateTime.Now.AddHours(-2),
                    UpdatedAt = DateTime.Now.AddHours(-2)
                },
                new TenTenEntry
                {
                    Id = 2,
                    TopicId = 2,
                    TopicSubject = "내일 가장 기대되는 일",
                    Content = "내일은 오랜만에 친구들과 만나서 맛있는 음식을 먹을 예정이에요. 정말 기대됩니다!",
                    UserId = 2,
                    IsReadByPartner = true,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    UpdatedAt = DateTime.Now.AddDays(-1)
                }
            };

            return tenTens;
        }
        catch (Exception)
        {
            return new List<TenTenEntry>();
        }
    }

    public async Task<List<TenTenEntry>> GetTenTensByTopicAsync(int topicId)
    {
        var allTenTens = await GetTenTensAsync();
        return allTenTens.Where(t => t.TopicId == topicId).ToList();
    }

    public async Task<TenTenEntry?> GetTenTenAsync(int id)
    {
        var tenTens = await GetTenTensAsync();
        return tenTens.FirstOrDefault(t => t.Id == id);
    }

    public async Task<TenTenEntry> CreateTenTenAsync(CreateTenTenRequest request)
    {
        try
        {
            await Task.Delay(300); // API 호출 시뮬레이션
            
            var newTenTen = new TenTenEntry
            {
                Id = DateTime.Now.Millisecond, // 임시 ID 생성
                TopicId = request.TopicId,
                TopicSubject = "주제", // 실제로는 Topic에서 가져와야 함
                Content = request.Content,
                UserId = 1, // 임시 사용자 ID
                IsReadByPartner = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return newTenTen;
        }
        catch (Exception)
        {
            throw new InvalidOperationException("10&10 생성 중 오류가 발생했습니다.");
        }
    }

    public async Task<bool> UpdateTenTenAsync(int id, UpdateTenTenRequest request)
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

    public async Task<bool> DeleteTenTenAsync(int id)
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

    public async Task<bool> MarkAsReadAsync(int id)
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