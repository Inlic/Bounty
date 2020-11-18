using System;
using Bounty.Controllers;
using Bounty.Repositories;

namespace Bounty.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }
    internal object GetOrCreateProfile(ProfilesController userInfo)
    {
      throw new NotImplementedException();
    }
  }
}