using System.Text;
using System.Text.Json;

namespace AT.Framework.OpenAI
{
    public class OpenAiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "your_api_key";

        public OpenAiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> GetGptResponse(string input)
        {
            var requestBody = new
            {
                model = "gpt-4.0",
                messages = new[]
                {
                new { role = "user", content = input }
            }
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var result = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(result);
            return json.RootElement
                       .GetProperty("choices")[0]
                       .GetProperty("message")
                       .GetProperty("content")
                       .GetString()!;
        }
    }
}
