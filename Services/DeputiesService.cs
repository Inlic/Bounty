using System;
using System.Collections.Generic;
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
    internal IEnumerable<Deputy> Get()
    {
      return _repo.Get();
    }

    internal Deputy GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Deputy Create(Deputy deputy)
    {
      return _repo.Create(deputy);
    }

    internal Deputy Update(Deputy deputy)
    {
      var original = _repo.GetById(deputy.Id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      deputy.Name = deputy.Name != null ? deputy.Name : original.Name;
      return _repo.Update(deputy);
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