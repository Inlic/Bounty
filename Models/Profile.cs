namespace Bounty.Models
{
  public class Profile
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Picture { get; set; }
    public decimal Income { get; set; }
    public City City { get; set; }
  }
}