using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using contracted.Models;
using contracted.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _bs;

    public ContractorsController(ContractorsService service)
    {
      _bs = service;
    }

    [HttpGet]
    public ActionResult<List<Contractor>> Get()
    {
      try
      {
        List<Contractor> contractors = _bs.Get();
        return Ok(contractors);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        Contractor contractor = _bs.Get(id);
        return Ok(contractor);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
    {
      try
      {
        Contractor created = _bs.Create(newContractor);
        return Ok(created);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Contractor>> Update(int id, [FromBody] Contractor editedContractor)
    {
      try
      {
        editedContractor.Id = id;
        Contractor contractor = _bs.Update(editedContractor);
        return Ok(contractor);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Contractor> Delete(int id)
    {
      try
      {
        Contractor contractor = _bs.Delete(id);
        return Ok(contractor);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }




  }
}