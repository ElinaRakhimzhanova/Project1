using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
 class DataRecord
    {
        //Should have properties which correspond to the Column Names in the file
        //i.e. CommonName,FormalName,TelephoneCode,CountryCode
        public String Name { get; set; }
        public String Surname { get; set; }
        
    }

    class StudentComparer : IEqualityComparer<DataRecord>
{
        public bool Equals(DataRecord x, DataRecord y)
        {
            if (x.Name == y.Name && 
                        x.Surname.ToLower() == y.Surname.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(DataRecord obj)
        {
            return obj.GetHashCode();
        }
}