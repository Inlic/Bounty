using System.Collections.Generic;
using System.Data;
using Bounty.Models;

namespace Bounty.Repositories
{
  public class AwardsRepository
  {
    private readonly IDbConnection _db;

    public AwardsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Award> Get()
    {
      return _db.Query<Award, City, Award>(@"
      SELECT a.*,
      c.*
      FROM awards
      ")
    }
  }
}