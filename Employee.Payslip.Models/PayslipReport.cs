using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Employee.Payslip.Models
{
    public class PayslipReport
    {
        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Pay Period")]
        public string PayPeriod { get; set; }

        [Display(Name = "Gross Income")]
        public ulong GrossIncome { get; set; }

        [Display(Name = "Income Tax")]
        public ulong IncomeTax { get; set; }

        [Display(Name = "Net Income")]
        public ulong NetIncome { get; set; }

        [Display(Name = "Super")]
        public ulong Super { get; set; }
    }
}
