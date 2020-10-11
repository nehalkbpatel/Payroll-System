using System;

namespace Employee.Payslip.Models
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal AnnualSalary { get; set; }

        public ushort SuperRate { get; set; }

        public string PaymentStartDate { get; set; }
    }
}
