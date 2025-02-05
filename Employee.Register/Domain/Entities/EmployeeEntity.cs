namespace Employee.Register.Domain.Entities
{
    public class EmployeeEntity
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate{ get; set; }
        public DateTime Hiredate { get; set; }
        public string AFP { get; set; } = string.Empty;
        public ChargeEntity Charge { get; set; }
        public int ChargeId { get; set; }
        public decimal Salary { get; set; }
    }
}
