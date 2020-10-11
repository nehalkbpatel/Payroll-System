using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Payslip.Models
{
    public class Payslip : Employee
    {
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public string PayPeriod
        {
            get
            {
                DateTime paymentDate = DateTime.ParseExact(PaymentStartDate, "ddMMyyyy", null);
                DateTime firstDay = new DateTime(paymentDate.Year, paymentDate.Month, 1);
                DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);

                return $"{firstDay.ToString("dd/MMM/yyyy")}-{lastDay.ToString("dd/MMM/yyyy")}";
            }
        }

        public ulong GrossIncome { get; set; }

        public ulong IncomeTax { get; set; }

        public ulong NetIncome { get; set; }

        public ulong Super { get; set; }

        public static Payslip GetPaySlipFromEmployee(Employee emp)
        {
            var paySlip = new Payslip();
            paySlip.FirstName = emp.FirstName;
            paySlip.LastName = emp.LastName;
            paySlip.AnnualSalary = emp.AnnualSalary;
            paySlip.SuperRate = emp.SuperRate;
            paySlip.PaymentStartDate = emp.PaymentStartDate;

            return paySlip;
        }
    }
}
