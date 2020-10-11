using Employee.Payslip.Helper.FileReader;
using Employee.Payslip.Helper.FileWriter;
using Employee.Payslip.Models;
using Employee.Payslip.Process;
using Microsoft.VisualBasic;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using Model = Employee.Payslip.Models;

namespace Employee.Payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            SalaryCalculator salaryCalculate = new SalaryCalculator();

            //string filePath = args[0];
            string filePath = "c:\\temp\\employeeDetail.csv";

            Reader fileReader = new CsvReader();
            List<Model.Employee> employees = fileReader.Read<Model.Employee>(filePath);

            //Testing 
            //var employees = GetEmployeeData();

            List<Model.Payslip> paySlips = salaryCalculate.CalculateTax(employees);

            PrintPayslip(paySlips);

            Writer fileWriter = new CsvWriter();
            fileWriter.Write<Model.PayslipReport>(paySlips.Select(x => 
                                new PayslipReport 
                                { 
                                    FullName = x.FullName, 
                                    PayPeriod = x.PayPeriod, 
                                    GrossIncome = x.GrossIncome, 
                                    IncomeTax = x.IncomeTax, 
                                    NetIncome = x.NetIncome, 
                                    Super = x.Super }).ToList(), "c:\\temp\\EmployeePaySlip.csv");

            Console.ReadKey();
        }

        private static void PrintPayslip(List<Model.Payslip> paySlips)
        {
            foreach(var slip in paySlips)
            {
                Console.WriteLine($"{slip.FullName},{slip.PayPeriod},{slip.GrossIncome},{slip.IncomeTax},{slip.NetIncome},{slip.Super}");
            }
        }
    }
}
