using Employee.Payslip.Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Payslip.Models
{
    public class TaxRange
    {
        private TaxRange(decimal fromAmount, decimal? toAmount, ulong fixAmount, decimal taxCentPerDollar, ulong taxCentApplyAfterDollar)
        {
            Range = new AmountRange(fromAmount, toAmount);

            FixTaxAmount = fixAmount;

            VariableTaxDetail = new VariableTax(taxCentPerDollar, taxCentApplyAfterDollar);
        }

        public static TaxRange Create(decimal fromAmount, decimal? toAmount, ulong fixAmount, decimal taxCentPerDollar, ulong taxCentApplyAfterDollar)
        {
            return new TaxRange(fromAmount, toAmount, fixAmount, taxCentPerDollar, taxCentApplyAfterDollar);
        }

        public AmountRange Range { get; set; }

        public ulong FixTaxAmount { get; set; }

        public VariableTax VariableTaxDetail { get; set; }

        public decimal CalculateTax(decimal amount)
        {
            decimal tax = 0;
            if (amount > Range.From)
            {
                decimal taxableAmount;
                if (Range.To != null && amount > Range.To)
                {
                    taxableAmount = Range.To.Value - Range.From;
                }
                else
                {
                    taxableAmount = amount - Range.From;
                }
                tax = (VariableTaxDetail.Calculate(taxableAmount) + FixTaxAmount )/ 12;

            }
            return tax;
        }
    }
}
