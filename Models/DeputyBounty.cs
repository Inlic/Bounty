namespace Bounty.Models
{
  public class DeputyBounty
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public int DeputyId { get; set; }
    public int BountyId { get; set; }
  }
}