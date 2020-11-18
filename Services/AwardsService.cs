using System;
using System.Collections.Generic;
using Bounty.Models;
using Bounty.Repositories;

namespace Bounty.Services
{
  public class AwardsService
  {
    private readonly AwardsRepository _repo;

    public AwardsService(AwardsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Award> Get()
    {
      return _repo.Get();
    }

    public Award GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    public Award Create(Award award)
    {
      return _repo.Create(award);
    }

    public Award Update(Award award)
    {
      var original = _repo.GetById(award.Id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      award.Description = award.Description != null ? award.Description : original.Description;
      award.Payout = original.Payout <= 0 && award.Payout > 0 ? award.Payout : original.Payout;
      return _repo.Update(award);
    }

    public bool Delete(int id)
    {
      var original = _repo.GetById(id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
      return true;
    }
  }
}