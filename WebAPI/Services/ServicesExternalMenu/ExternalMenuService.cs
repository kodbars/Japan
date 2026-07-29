using Microsoft.Extensions.Options;
using Models_DB_and_Request.DB;
using Models_DB_and_Request.ModelsRequest.ExternalMenu;
using Models_DB_and_Request.ModelsRequest.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WebAPI.Services.ServicesExternalMenu.IServices;
using WebAPI.Services.ServicesExternalMenuCacheDB;
using WebAPI.Services.ServicesExternalMenuCacheDB.IServices;
using WebAPI.Services.ServicesToken.IServices;

namespace WebAPI.Services.ServicesExternalMenu
{
    public class ExternalMenuService : IExternalMenuService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IExternalMenuCacheDB _cachedMenuDB;
        private readonly ILogger<ExternalMenuService> _logger;
        private readonly IikoApiOptions _options;
        private readonly ITokenService _token;

        private CityMenu _cityMenu;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromDays(1); // 1 день

        public ExternalMenuService(IHttpClientFactory httpClientFactory, ILogger<ExternalMenuService> logger, IOptions<IikoApiOptions> options, ITokenService token, IExternalMenuCacheDB cachedMenuDB)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _options = options.Value;
            _token = token;
            _cachedMenuDB = cachedMenuDB;
        }

        public async Task<Root> GetExternalMenuAsync()
        {
            string city = "Кемерово-1";

            _cityMenu = await _cachedMenuDB.GetMenuCacheAsync(city);
            var menu = JsonSerializer.Deserialize<Root>(_cityMenu.ExternalMenu);
            // Если кэш ещё свежий — отдаём его
            if (menu != null && DateTime.UtcNow - _cityMenu.CacheDayExternalMenu < _cacheDuration)
            {
                _logger.LogInformation("Возвращаем закэшированное меню");
                return menu;
            }

            _logger.LogInformation("Запрос токена ExternalMenuService");
            string token = await _token.GetTokenAsync();

            _logger.LogInformation("Запрос Внешнего меню");
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var requestBody = new { externalMenuId = _cityMenu.ExternalMenuId.ToString(), organizationIds = new List<Guid>() { _cityMenu.OrganizationId } };
            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_options.BaseUrl}/2/menu/by_id", content);

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
                _cityMenu.ExternalMenu = responseJson;
                _cityMenu.CacheDayExternalMenu = DateTime.UtcNow;
                await _cachedMenuDB.UpdateMenuCacheAsync(_cityMenu);
                _logger.LogInformation("Меню успешно обновлено в кэше");
            }

            return externalMenuResponse ?? new Root();
        }
    }
}
