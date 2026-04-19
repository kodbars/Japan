namespace WebAPI.Models
{
    public class IikoApiOptions
    {
        public string BaseUrl { get; set; }
        public string ApiLogin { get; set; }
        public string ExternalMenuId { get; set; }
        public List<string> OrganizationIds { get; set; }
    }
}
