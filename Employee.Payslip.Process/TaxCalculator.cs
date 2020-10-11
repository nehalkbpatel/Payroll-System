using Employee.Payslip.Models;
using Employee.Payslip.Process.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace Employee.Payslip.Process
{
    public class TaxCalculator : TaxContainer
    {
        TaxRange[] _taxRange;
        decimal _amount;

        public TaxCalculator(decimal amount)
        {
            _amount = amount;
            _taxRange = FillTaxRange().ToArray();
        }

        public TaxIterator GetTaxIterator()
        {
            return new TaxCalculationIterator(_amount, _taxRange);
        }

        public decimal Calculate()
        {
            TaxIterator finalIteration = null;
            for (TaxIterator iter = GetTaxIterator(); iter.HasNext();)
            {
                iter.Next();
                finalIteration = iter;
            }
            return finalIteration.CalculateTax();
        }

        private List<TaxRange> FillTaxRange()
        {
            return new List<TaxRange>()
            {
                TaxRange.Create(0, 18200, 0, 0, 0),
                TaxRange.Create(18201,37000, 0, 19, 18200),
                TaxRange.Create(37001, 87000, 3572, (decimal)32.5, 37000),
                TaxRange.Create(87001, 180000, 19822, 37, 87000),
                TaxRange.Create(180000, null, 54232, 45, 180000)
            };
        }

        private class TaxCalculationIterator : TaxIterator
        {
            int index;
            decimal _amount;
            TaxRange[] _taxRange;

            public TaxCalculationIterator(decimal amount, TaxRange[] taxRange)
            {
                _amount = amount;
                _taxRange = taxRange;
            }

            public bool HasNext()
            {
                if(index < _taxRange.Length)
                {
                    var slab = _taxRange[index];
                    if(slab.Range.From <= _amount && (slab.Range.To == null || slab.Range.To >= _amount))
                    {
                        return false;
                    }
                }
                return true;
            }

            public void Next()
            {
                if (this.HasNext())
                {
                    index++;
                }
            }

            public decimal CalculateTax()
            {
                return _taxRange[index].CalculateTax(_amount);
            }
        }
    }
}
