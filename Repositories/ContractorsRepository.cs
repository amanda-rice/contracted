using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal List<Contractor> GetAll()
    {
      string sql = "SELECT * FROM contractor";
      return _db.Query<Contractor>(sql).ToList();
    }

    internal Contractor GetById(int id)
    {
      string sql = @"
      SELECT 
        *
      FROM contractor b
      WHERE b.id = @id;
      ";
      return _db.Query<Contractor>(sql, new { id }).FirstOrDefault();
    }

    internal Contractor Create(Contractor newContractor)
    {
      string sql = @"
        INSERT INTO contractor
        (name)
        VALUES
        (@Name);
        SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, newContractor);
      return GetById(id);
    }

    internal Contractor Update(Contractor original)
    {
      string sql = @"
        UPDATE contractor
        SET
            name = @Name
        WHERE id = @Id;
      ";
      _db.Execute(sql, original);
      return GetById(original.Id);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractor WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}