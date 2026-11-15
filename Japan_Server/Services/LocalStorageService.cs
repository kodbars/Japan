using Microsoft.JSInterop;
using System.Text.Json;

namespace Japan_Server.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jSRuntime;

        public LocalStorageService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task<T> GetTAsync<T>(string key) where T : class
        {
            var jsModule = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            var data = await jsModule.InvokeAsync<string>("get", key);
            if (string.IsNullOrEmpty(data))
            {
                return null!;
            }
            return JsonSerializer.Deserialize<T>(data)!;
        }

        public async Task<string> GetStringAsync(string key)
        {
            var jsModule = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            return await jsModule.InvokeAsync<string>("get", key);
        }

        public async Task RemoveAsync(string key)
        {
            var jsModule = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            await jsModule.InvokeAsync<string>("remove", key);
        }

        public async Task SetAcync<T>(string key, T item) where T : class
        {
            var jsModule = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            var data = JsonSerializer.Serialize(item);
            await jsModule.InvokeAsync<string>("set", key, data);
        }

        public async Task SetStringAsync(string key, string value)
        {
            var jsModule = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            await jsModule.InvokeAsync<string>("set", key, value);
        }
    }
}
