using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;

    public ContractorsService(ContractorsRepository repo)
    {
      _repo = repo;
    }
    internal List<Contractor> Get()
    {
      List<Contractor> contractors = _repo.GetAll();
      return contractors;
    }
    internal Contractor Get(int id)
    {
      Contractor contractor = _repo.GetById(id);
      if (contractor == null)
      {
        throw new Exception("Invalid Id");
      }
      return contractor;
    }

    internal Contractor Create(Contractor newContractor)
    {
      return _repo.Create(newContractor);
    }

    internal Contractor Update(Contractor editedContractor)
    {
      Contractor original = Get(editedContractor.Id);
      original.Name = editedContractor.Name.Length > 0 ? editedContractor.Name : original.Name;
      return _repo.Update(original);
    }

    internal Contractor Delete(int contractorId)
    {
      Contractor contractorToDelete = Get(contractorId);
      _repo.Delete(contractorId);
      return contractorToDelete;
    }
  }
}