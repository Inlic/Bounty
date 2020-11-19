using System;
using System.Collections.Generic;
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
    internal IEnumerable<City> Get()
    {
      return _repo.Get();
    }

    internal City GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal City Create(City city)
    {
      return _repo.Create(city);
    }

    internal City Update(City city)
    {
      var original = _repo.GetById(city.Id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      city.Name = city.Name != null ? city.Name : original.Name;
      return _repo.Update(city);
    }

    internal bool Delete(int id)
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