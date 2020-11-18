using System.Threading.Tasks;
using Bounty.Models;
using Bounty.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bounty.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _service;
    public ProfilesController(ProfilesService service)
    {
      _service = service;
    }
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        ProfilesController userInfo = await HttpContext.GetUserInfoAsync<ProfilesController>();
        return Ok(_service.GetOrCreateProfile(userInfo));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}