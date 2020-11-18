using System.Collections.Generic;
using Bounty.Models;
using Bounty.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bounty.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class DeputiesController : ControllerBase
  {
    private readonly DeputiesService _service;
    public DeputiesController(DeputiesService service)
    {
      _service = service;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Deputy>> Get()
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
    public ActionResult<Deputy> Get(int id)
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
    public ActionResult<Deputy> Create([FromBody] Deputy deputy)
    {
      try
      {
        return Ok(_service.Create(deputy));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{id")]
    public ActionResult<Deputy> Update([FromBody] Deputy deputy, int id)
    {
      try
      {
        deputy.Id = id;
        return Ok(_service.Update(deputy));
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