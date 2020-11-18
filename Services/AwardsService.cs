using System;
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

    internal object Get()
    {
      return _repo.Get();
    }

    internal object GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal object Create(Award award)
    {
      throw new NotImplementedException();
    }

    internal object Update(Award award)
    {
      throw new NotImplementedException();
    }

    internal object Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}