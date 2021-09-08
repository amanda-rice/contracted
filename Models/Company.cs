using System.ComponentModel.DataAnnotations;

namespace contracted.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}