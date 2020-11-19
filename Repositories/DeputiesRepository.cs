using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bounty.Models;
using Dapper;

namespace Bounty.Repositories
{
  public class DeputiesRepository
  {
    private readonly IDbConnection _db;

    public DeputiesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Deputy> Get()
    {
      return _db.Query<Deputy>(@"
      SELECT *
      FROM deputies;");
    }
    internal Deputy GetById(int id)
    {
      return _db.Query<Deputy>(@"
      SELECT *
      FROM deputies
      WHERE id = @id", new { id }).FirstOrDefault();
    }

    internal Deputy Create(Deputy deputy)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO deputies(name)
      VALUES(@Name); SELECT LAST_INSERT_ID();", deputy);
      deputy.Id = id;
      return deputy;
    }

    internal Deputy Update(Deputy deputy)
    {
      _db.Execute(@"
      UPDATE deputies
      SET
      name = @Name
      WHERE id = @Id;", deputy);
      return deputy;
    }

    internal bool Delete(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM deputies WHERE id = @id", new { id });
      return success > 0;
    }
  }
}