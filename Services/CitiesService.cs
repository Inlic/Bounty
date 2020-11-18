using System;
using Bounty.Models;
using Bounty.Repositories;

namespace Bounty.Services
{
  public class CitiesService
  {
    private readonly CitiesRepository _repo;

    public CitiesService(CitiesRepository repo)
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

    internal object Create(City city)
    {
      throw new NotImplementedException();
    }

    internal object Update(City city)
    {
      throw new NotImplementedException();
    }

    internal object Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}