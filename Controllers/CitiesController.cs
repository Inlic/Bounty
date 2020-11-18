using System.Collections.Generic;
using Bounty.Models;
using Bounty.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bounty.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class CitiesController : ControllerBase
  {
    private readonly CitiesService _service;
    public CitiesController(CitiesService service)
    {
      _service = service;
    }
    [HttpGet]
    public ActionResult<IEnumerable<City>> Get()
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
    public ActionResult<City> Get(int id)
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
    public ActionResult<City> Create([FromBody] City city)
    {
      try
      {
        return Ok(_service.Create(city));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{id")]
    public ActionResult<City> Update([FromBody] City city, int id)
    {
      try
      {
        city.Id = id;
        return Ok(_service.Update(city));
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