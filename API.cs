using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class API
{
    private readonly HttpClient httpClient;

    public API()
    {
        // HttpClient 초기화
        httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://3.38.255.138/dev/api/User/register") // API 기본 주소 설정
        };
    }

    // GET 요청 메서드
    public async Task<string?> GetAsync(string endpoint)
    {
        try
        {
            // GET 요청 전송
            HttpResponseMessage response = await httpClient.GetAsync(endpoint);

            // 응답 처리
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync(); // 응답 데이터 반환
            }
            else
            {
                Console.WriteLine($"GET 요청 실패: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GET 요청 오류: {ex.Message}");
            return null;
        }
    }

    // POST 요청 메서드
    public async Task<string?> PostAsync<T>(string endpoint, T data)
    {
        try
        {
            // POST 요청 전송
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(endpoint, data);

            // 응답 처리
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync(); // 응답 데이터 반환
            }
            else
            {
                Console.WriteLine($"POST 요청 실패: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"POST 요청 오류: {ex.Message}");
            return null;
        }
    }

}
