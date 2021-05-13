using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelperAndJSON
{
    class ReadCSV_And_WriteJSON
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"C:\Users\vicun\source\repos\CSVHelperAndJSON\CSVHelperAndJSON\Utility\Addresses.csv";
            string exportFilePath = @"C:\Users\vicun\source\repos\CSVHelperAndJSON\CSVHelperAndJSON\Utility\export.csv";
            using ( var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read Data Successfully from address.csv");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.firstname);
                    Console.Write("\t" + addressData.lastname);
                    Console.Write("\t" + addressData.address);
                    Console.Write("\t" + addressData.city);
                    Console.Write("\t" + addressData.state);
                    Console.Write("\t" + addressData.code);
                }
                Console.WriteLine("**************Reading from csv file and write to csv file");
                
                //writing json file
                JsonSerializer serializer = new JsonSerializer();
                using(StreamWriter sw = new StreamWriter(exportFilePath))
                using(JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }                
            }
        }
    }
}
