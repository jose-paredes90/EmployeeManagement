﻿using Employee.Register.Domain.Entities;
using MediatR;

namespace Employee.Register.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeEntity>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public string? AFP { get; set; }
        public int ChargeId { get; set; }
        public decimal Salary { get; set; }
    }
}