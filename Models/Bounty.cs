namespace Bounty.Models
{
  public class Bounty
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public int Views { get; set; }
    public decimal Payout { get; set; }
    public City Creator { get; set; }
  }
}