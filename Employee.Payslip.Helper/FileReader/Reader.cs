using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Payslip.Helper.FileReader
{
    public abstract class Reader
    {
        public abstract List<T> Read<T>(string filePath) where T : new();
    }
}
