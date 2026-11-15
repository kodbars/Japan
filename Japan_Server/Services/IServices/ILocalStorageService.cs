namespace Japan_Server.Services
{
    public interface ILocalStorageService
    {
        Task SetStringAsync(string key, string value);
        Task SetAcync<T>(string key, T item) where T : class;
        Task<string> GetStringAsync(string key);
        Task<T> GetTAsync<T>(string key) where T : class;
        Task RemoveAsync(string key);
    }
}
