using System.ComponentModel.DataAnnotations;

namespace CodeFirstWebApi.DTOs
{
    public class StudentDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
