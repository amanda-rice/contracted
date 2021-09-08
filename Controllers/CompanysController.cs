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
  [Route("/api/companies")]
  public class CompanysController : ControllerBase
  {
    private readonly CompanysService _bs;

    public CompanysController(CompanysService service)
    {
      _bs = service;
    }

    [HttpGet]
    public ActionResult<List<Company>> Get()
    {
      try
      {
        List<Company> companys = _bs.Get();
        return Ok(companys);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Company> Get(int id)
    {
      try
      {
        Company company = _bs.Get(id);
        return Ok(company);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Company> Create([FromBody] Company newCompany)
    {
      try
      {
        Company created = _bs.Create(newCompany);
        return Ok(created);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Company>> Update(int id, [FromBody] Company editedCompany)
    {
      try
      {
        editedCompany.Id = id;
        Company company = _bs.Update(editedCompany);
        return Ok(company);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Company> Delete(int id)
    {
      try
      {
        Company company = _bs.Delete(id);
        return Ok(company);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }




  }
}