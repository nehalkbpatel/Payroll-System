using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Payslip.Helper.FileWriter
{
    public abstract class Writer
    {
        public abstract void Write<T>(List<T> items, string path);
       
    }
}
