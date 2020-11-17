using System.Collections.Generic;

namespace Bounty.Models
{
  public class Agency
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Income { get; set; }
    public City City { get; set; }
  }
}