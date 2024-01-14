namespace SignalR.Entity.Entities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
