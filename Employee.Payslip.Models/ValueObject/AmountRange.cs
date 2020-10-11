using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Payslip.Models.ValueObject
{
    public class AmountRange
    {
        public AmountRange(decimal from, decimal? to)
        {
            From = from;
            To = to;
        }

        public decimal From { get; set; }

        public decimal? To { get; set; }
    }
}
