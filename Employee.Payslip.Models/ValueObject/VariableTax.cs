using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Payslip.Models.ValueObject
{
    public class VariableTax
    {
        public VariableTax(decimal centMultiplier, ulong taxAfterDollar)
        {
            CentMultiplier = centMultiplier;
            TaxAfterDollar = taxAfterDollar;
        }

        public decimal CentMultiplier { get; set; }

        public ulong TaxAfterDollar { get; set; }

        public decimal Calculate(decimal taxableAmount)
        {
            return (taxableAmount * CentMultiplier) / 100;
        }
    }
}
