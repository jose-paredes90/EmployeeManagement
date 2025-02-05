namespace Employee.Register.Application.Commands
{
    public class UpdateEmployeeCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public string AFP { get; set; }
        public int ChargeId { get; set; }
        public decimal Salary { get; set; }
    }
}
