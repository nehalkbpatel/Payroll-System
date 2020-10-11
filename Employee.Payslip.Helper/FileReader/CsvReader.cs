using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Employee.Payslip.Helper.FileReader
{
    public class CsvReader : Reader
    {
        public override List<T> Read<T>(string filePath)
        {
            List<T> records = null;
            CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
            configuration.HasHeaderRecord = false;
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvHelper.CsvReader(reader, configuration))
            {
                records = csv.GetRecords<T>().ToList();
            }
            return records;
        }
    }
}
