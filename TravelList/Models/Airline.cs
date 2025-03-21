public class Airline
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double Rating { get; set; }
    public decimal TicketPrice { get; set; }
    public int RatingCount { get; internal set; }
}
