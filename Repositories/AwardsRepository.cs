using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

    public Award GetById(int id)
    {
      return _db.Query<Award, City, Award>(@"
      SELECT a.*,
      c.*
      FROM awards a
      JOIN cities c ON c.id = a.cityid
      WHERE a.id = @id", (award, city) =>
      {
        award.City = city;
        return award;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    public Award Create(Award award)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO awards(description, payout, cityid)
      VALUES(@CityId, @Description, @Payout); SELECT LAST_INSERT_ID();
      ", award);
      award.Id = id;
      return award;
    }

    public Award Update(Award award)
    {
      _db.Execute(@"
      UPDATE awards
      SET
      description = @description
      payout = @payout
      WHERE id = @Id
      ", award);
      return award;
    }

    public bool Delete(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM awards WHERE id = @id
      ", new { id });
      return success > 0;
    }
  }
}