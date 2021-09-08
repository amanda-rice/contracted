using System.ComponentModel.DataAnnotations;

namespace contracted.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int ContractorId { get; set; }
        public int CompanyId { get;  set;}
  }
}