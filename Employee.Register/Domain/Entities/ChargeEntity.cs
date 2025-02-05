namespace Employee.Register.Domain.Entities
{
    public class ChargeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeEntity> Employee { get; set; }
    }
}
