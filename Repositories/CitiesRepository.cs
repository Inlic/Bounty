using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bounty.Models;
using Dapper;

namespace Bounty.Repositories
{
  public class CitiesRepository
  {
    private readonly IDbConnection _db;

    public CitiesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<City> Get()
    {
      return _db.Query<City>(@"
      SELECT *
      FROM cities;");
    }
    internal City GetById(int id)
    {
      return _db.Query<City>(@"
      SELECT *
      FROM cities
      WHERE id = @id", new { id }).FirstOrDefault();
    }

    internal City Create(City city)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO cities(name)
      VALUES(@Name); SELECT LAST_INSERT_ID();", city);
      city.Id = id;
      return city;
    }

    internal City Update(City city)
    {
      _db.Execute(@"
      UPDATE cities
      SET
      name = @Name
      WHERE id = @Id;", city);
      return city;
    }

    internal bool Delete(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM cities WHERE id = @id", new { id });
      return success > 0;
    }
  }
}