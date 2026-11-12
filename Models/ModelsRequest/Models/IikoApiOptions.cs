namespace Models_DB_and_Request.ModelsRequest.Models
{
    public class IikoApiOptions
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string AppId { get; set; }
        public string ClientSecret { get; set; }
        public string ExternalMenuId { get; set; }
        public List<string> OrganizationIds { get; set; }
    }
}
