using System.Collections.Generic;
using System.Data;
using Bounty.Models;
using Dapper;

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
      FROM awards a
      JOIN cities c ON c.id = a.cityid;
      ", (award, city) =>
      {
        award.City = city;
        return award;
      }, splitOn: "id"
      );
    }
  }
}