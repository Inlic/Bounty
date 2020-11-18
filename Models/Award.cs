namespace Bounty.Models
{
  public class Award
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Payout { get; set; }
    public City City { get; set; }
  }
}