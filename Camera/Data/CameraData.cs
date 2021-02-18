using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Data
{
    public class CameraRow
    {
        [Index(0)]
        public string Name { get; set; }
        [Index(1)]
        public string Latitude { get; set; }
        [Index(2)]
        public string Longitude { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Name} | {Latitude} | {Longitude}");
        }
    }
    
    public class CameraData: ICamaraData
    {
        public IEnumerable<CameraRow> GetData()
        {
            return getData();
        }

        public IEnumerable<CameraRow> SearchName(string name)
        {
            throw new System.NotImplementedException();
        }

        //https://stackoverflow.com/questions/59787783/why-cant-i-convert-from-system-io-streamwriter-to-csvhelper-iserializer
        private IEnumerable<CameraRow> getData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
                Delimiter = ";",
            };
            using (var reader = new StreamReader("../Data/data/cameras-defb.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<CameraRow>().ToList();
            }
        }
    }
}