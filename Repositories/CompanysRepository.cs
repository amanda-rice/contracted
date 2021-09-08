using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class CompanysRepository
  {
    private readonly IDbConnection _db;

    public CompanysRepository(IDbConnection db)
    {
      _db = db;
    }


    internal List<Company> GetAll()
    {
      string sql = "SELECT * FROM company";
      return _db.Query<Company>(sql).ToList();
    }

    internal Company GetById(int id)
    {
      string sql = @"
      SELECT 
        *
      FROM company b
      WHERE b.id = @id;
      ";
      return _db.Query<Company>(sql, new { id }).FirstOrDefault();
    }

    internal Company Create(Company newCompany)
    {
      string sql = @"
        INSERT INTO company
        (name)
        VALUES
        (@Name);
        SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, newCompany);
      return GetById(id);
    }

    internal Company Update(Company original)
    {
      string sql = @"
        UPDATE company
        SET
            name = @Name
        WHERE id = @Id;
      ";
      _db.Execute(sql, original);
      return GetById(original.Id);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM company WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}