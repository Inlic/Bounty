using System;
using System.Data;
using Bounty.Controllers;
using Bounty.Models;
using Dapper;

namespace Bounty.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Profile GetById(string id)
    {
      return _db.QueryFirstOrDefault<Profile>(@"
      SELECT *
      FROM profiles
      WHERE id = @id;", new { id });
    }

    internal Profile Create(Profile userInfo)
    {
      _db.Execute(@"
      INSERT INTO profiles(id, email, name, picture)
      VALUES(@Id, @Email, @Name, @Picture);      
      ", userInfo);
      return userInfo;
    }
  }
}
