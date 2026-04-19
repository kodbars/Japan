using WebAPI.Models;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using WebAPI.Services.ServicesToken.IServices;

namespace WebAPI.Services.ServicesToken
{
    public class TokenService : ITokenService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TokenService> _logger;
        private readonly IikoApiOptions _options;

        private string _cachedToken;
        private DateTime _tokenExpiry;

        public TokenService(
            IHttpClientFactory httpClientFactory,
            IOptions<IikoApiOptions> options,
            ILogger<TokenService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<string> GetTokenAsync()
        {
            // Возвращаем закэшированный токен, если он ещё жив (обновляем за 5 минут до истечения)
            if (!string.IsNullOrEmpty(_cachedToken) && _tokenExpiry > DateTime.UtcNow)
                return _cachedToken;

            _logger.LogInformation("Запрос нового токена iiko...");

            var client = _httpClientFactory.CreateClient();
            var requestBody = new { apiLogin = _options.ApiLogin };
            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_options.BaseUrl}/1/access_token", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                _logger.LogError("Ошибка получения токена. Статус: {StatusCode}, Тело: {ErrorBody}",
                    response.StatusCode, errorBody);
                throw new Exception($"Не удалось получить токен: {response.StatusCode} - {errorBody}");
            }
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseJson);

            if (tokenResponse?.Token == null)
                throw new Exception("Не удалось получить токен от iiko API");

            _cachedToken = tokenResponse.Token;
            // Токен живёт 60 минут, обновляем через 55 минут
            _tokenExpiry = DateTime.UtcNow.AddMinutes(55);

            _logger.LogInformation("Токен успешно получен");
            return _cachedToken;
        }
    }
}
