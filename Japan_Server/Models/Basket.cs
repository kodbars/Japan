namespace Japan_Server.Models
{
    public class Basket
    {
        public string? SkyID { get; set; }
        public string? ImageRoot { get; set; }
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Amount { get; set; } = 1;
    }
}
