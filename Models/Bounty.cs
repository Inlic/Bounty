namespace Bounty.Models
{
  public class Bounty
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public double Payout { get; set; }
    public City Creator { get; set; }
  }
}