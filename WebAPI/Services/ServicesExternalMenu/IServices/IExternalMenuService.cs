using Models_DB_and_Request.ModelsRequest.ExternalMenu;

namespace WebAPI.Services.ServicesExternalMenu.IServices
{
    public interface IExternalMenuService
    {
        Task<Root> GetExternalMenuAsync();
    }
}
