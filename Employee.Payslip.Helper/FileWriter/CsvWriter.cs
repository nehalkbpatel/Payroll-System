using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Employee.Payslip.Helper.FileWriter
{
    public class CsvWriter : Writer
    {
        public override void Write<T>(List<T> items, string path)
        {
            CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
            configuration.HasHeaderRecord = false;
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvHelper.CsvWriter(writer, configuration))
            {
                csv.WriteRecords(items);
            }
        }
    }
}
