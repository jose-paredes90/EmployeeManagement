using System.ComponentModel.DataAnnotations;

namespace Employee.Register.Application.DTO
{
    public class CreateEmployeeRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string AFP { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public DateTime Hiredate { get; set; }
        public decimal Salary { get; set; }
        [Required]
        public int ChargeId { get; set; }
    }
}