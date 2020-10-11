using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Payslip.Process.Contract
{
    public interface TaxContainer
    {
        public TaxIterator GetTaxIterator();
    }
}
