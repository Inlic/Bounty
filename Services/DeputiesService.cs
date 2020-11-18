using System;
using Bounty.Models;
using Bounty.Repositories;

namespace Bounty.Services
{
  public class DeputiesService
  {
    private readonly DeputiesRepository _repo;

    public DeputiesService(DeputiesRepository repo)
    {
      _repo = repo;
    }
    internal object Get()
    {
      throw new NotImplementedException();
    }

    internal object GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal object Create(Deputy deputy)
    {
      throw new NotImplementedException();
    }

    internal object Update(Deputy deputy)
    {
      throw new NotImplementedException();
    }

    internal object Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}