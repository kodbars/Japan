namespace WebAPI.Services.ServicesToken.IServices
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync();
    }
}
