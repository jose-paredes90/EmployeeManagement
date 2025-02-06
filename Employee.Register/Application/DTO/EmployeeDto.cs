namespace Employee.Register.Application.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string AFP { get; set; }
        public ChargeDto Charge { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public decimal Salary { get; set; }
    }
}