using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using Models_DB_and_Request.ModelsRequest.Models;
using WebAPI.Services.ServicesToken.IServices;
using WebAPI.Services.ServicesExternalMenu.IServices;
using Models_DB_and_Request.ModelsRequest.ExternalMenu;

namespace WebAPI.Services.ServicesExternalMenu
{
    public class ExternalMenuService : IExternalMenuService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ExternalMenuService> _logger;
        private readonly IikoApiOptions _options;
        private readonly ITokenService _token;

        // Кэш и время последнего обновления
        private Root _cachedMenu;
        private DateTime _lastFetch = DateTime.MinValue;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(60); // 60 минут

        public ExternalMenuService(IHttpClientFactory httpClientFactory, ILogger<ExternalMenuService> logger, IOptions<IikoApiOptions> options, ITokenService token)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _options = options.Value;
            _token = token;
        }

        public async Task<Root> GetExternalMenuAsync()
        {
            // Если кэш ещё свежий — отдаём его
            if (_cachedMenu != null && DateTime.UtcNow - _lastFetch < _cacheDuration)
            {
                _logger.LogInformation("Возвращаем закэшированное меню");
                return _cachedMenu;
            }

            _logger.LogInformation("Запрос токена ExternalMenuService");
            string token = await _token.GetTokenAsync();

            _logger.LogInformation("Запрос Внешнего меню");
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var requestBody = new { externalMenuId = _options.ExternalMenuId, organizationIds = _options.OrganizationIds };
            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_options.BaseUrl}/2/menu/by_id", content);

            // Если iiko вернул 429 TooManyRequests
            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                _logger.LogWarning("Превышен лимит запросов к iiko. Возвращаем кэш (если есть)");
                if (_cachedMenu != null)
                {
                    // Можно продлить срок жизни кэша, чтобы не падать
                    _lastFetch = DateTime.UtcNow;
                    return _cachedMenu;
                }
                throw new Exception("Превышен лимит запросов к iiko, повторите позже.");
            }

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                _logger.LogError("Ошибка получения Внешнего меню. Статус: {StatusCode}, Тело: {ErrorBody}",
                    response.StatusCode, errorBody);
                throw new Exception($"Не удалось получить Внешнее меню: {response.StatusCode} - {errorBody}");
            }

            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            var externalMenuResponse = JsonSerializer.Deserialize<Root>(responseJson);

            // Обновляем кэш
            if (externalMenuResponse != null)
            {
                _cachedMenu = externalMenuResponse;
                _lastFetch = DateTime.UtcNow;
                _logger.LogInformation("Меню успешно обновлено в кэше");
            }

            return externalMenuResponse ?? new Root();
        }
    }
}
