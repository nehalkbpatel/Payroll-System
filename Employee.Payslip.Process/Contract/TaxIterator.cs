using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Payslip.Process.Contract
{
    public interface TaxIterator
    {
        public bool HasNext();

        public void Next();

        public decimal CalculateTax();
    }
}
