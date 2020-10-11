using System;
using System.Collections.Generic;
using Xunit;
using Model = Employee.Payslip.Models;

namespace Employee.Payslip.Process.Test
{
    public class SalaryCalculatorTest
    {
        private readonly SalaryCalculator _salaryCalculator;

        public SalaryCalculatorTest()
        {
            _salaryCalculator = new SalaryCalculator();
        }

        [Fact]
        public void CalculateTaxTest()
        {
            var employees = GetEmployeeData();

            var paySlips = _salaryCalculator.CalculateTax(employees);

            var expectedPaySlips = ExpectedPaySlips();

            Assert.Equal(2, paySlips.Count);
            Assert.Equal(expectedPaySlips[0].GrossIncome, paySlips[0].GrossIncome);
            Assert.Equal(expectedPaySlips[0].IncomeTax, paySlips[0].IncomeTax);
            Assert.Equal(expectedPaySlips[0].NetIncome, paySlips[0].NetIncome);
            Assert.Equal(expectedPaySlips[0].Super, paySlips[0].Super);

            Assert.Equal(expectedPaySlips[1].GrossIncome, paySlips[1].GrossIncome);
            Assert.Equal(expectedPaySlips[1].IncomeTax, paySlips[1].IncomeTax);
            Assert.Equal(expectedPaySlips[1].NetIncome, paySlips[1].NetIncome);
            Assert.Equal(expectedPaySlips[1].Super, paySlips[1].Super);
        }

        private List<Model.Employee> GetEmployeeData()
        {
            return new List<Model.Employee>()
            {
                new Model.Employee()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    AnnualSalary = 60050,
                    SuperRate = 9,
                    PaymentStartDate = "01032017"
                },
                new Model.Employee()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    AnnualSalary = 120000,
                    SuperRate = 10,
                    PaymentStartDate = "01032017"
                }
            };
        }

        private List<Model.PayslipReport> ExpectedPaySlips()
        {
            return new List<Model.PayslipReport>()
            {
                new Model.PayslipReport()
                {
                    FullName = "John Doe",
                    PayPeriod = "01/Mar/2017–31/Mar/2017",
                    GrossIncome = 5004,
                    IncomeTax = 922,
                    NetIncome = 4082,
                    Super = 450
                },
                new Model.PayslipReport()
                {
                    FullName = "Jane Doe",
                   PayPeriod = "01/Mar/2017–31/Mar/2017,",
                     GrossIncome = 10000,
                    IncomeTax = 7331,
                    NetIncome = 4082,
                    Super = 1000
                }
            };
        }
    }
}
