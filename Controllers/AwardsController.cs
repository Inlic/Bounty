using System.Collections.Generic;
using Bounty.Services;
using Bounty.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bounty.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class AwardsController : ControllerBase
  {
    private readonly AwardsService _service;

    public AwardsController(AwardsService service)
    {
      _service = service;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Award>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Award> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPost]
    public ActionResult<Award> Create([FromBody] Award award)
    {
      try
      {
        return Ok(_service.Create(award));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Award> Update([FromBody] Award award, int id)
    {
      try
      {
        award.Id = id;
        return Ok(_service.Update(award));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<bool> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}