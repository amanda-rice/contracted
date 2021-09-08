using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class CompanysService
  {
    private readonly CompanysRepository _repo;

    public CompanysService(CompanysRepository repo)
    {
      _repo = repo;
    }
    internal List<Company> Get()
    {
      List<Company> companys = _repo.GetAll();
      return companys;
    }
    internal Company Get(int id)
    {
      Company company = _repo.GetById(id);
      if (company == null)
      {
        throw new Exception("Invalid Id");
      }
      return company;
    }

    internal Company Create(Company newCompany)
    {
      return _repo.Create(newCompany);
    }

    internal Company Update(Company editedCompany)
    {
      Company original = Get(editedCompany.Id);
      original.Name = editedCompany.Name.Length > 0 ? editedCompany.Name : original.Name;
      return _repo.Update(original);
    }

    internal Company Delete(int companyId)
    {
      Company companyToDelete = Get(companyId);
      _repo.Delete(companyId);
      return companyToDelete;
    }
  }
}