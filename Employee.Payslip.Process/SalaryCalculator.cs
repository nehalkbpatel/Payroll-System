using System;
using System.Collections.Generic;
using System.Text;
using Model = Employee.Payslip.Models;

namespace Employee.Payslip.Process
{
    public class SalaryCalculator
    {
        public List<Model.Payslip> CalculateTax(List<Model.Employee> employees)
        {

            List<Model.Payslip> paySlips = new List<Model.Payslip>();
            foreach (Model.Employee item in employees)
            {
                var paySlip = Model.Payslip.GetPaySlipFromEmployee(item);
               
                TaxCalculator taxCalculator = new TaxCalculator(paySlip.AnnualSalary);
                var incomeTax = taxCalculator.Calculate();
                paySlip.IncomeTax = (ulong)Math.Round(incomeTax);
                paySlip.GrossIncome = (ulong)Math.Floor(paySlip.AnnualSalary / 12);
                paySlip.NetIncome = paySlip.GrossIncome - paySlip.IncomeTax;
                paySlip.Super = paySlip.GrossIncome * paySlip.SuperRate / 100;

                paySlips.Add(paySlip);
            }
            return paySlips;
        }
    }
}
