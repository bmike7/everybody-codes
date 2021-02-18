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
    public interface ICameraRow
    {
        string Name { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
    }
    public class CameraRow: ICameraRow
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
        public IEnumerable<CameraRow> GetData() => getData();

        public IEnumerable<CameraRow> SearchName(string name)
            => from row in getData()
                where row.Name.Contains(name)
                select row;

        // https://joshclose.github.io/CsvHelper/getting-started/#reading-a-csv-file
        // https://joshclose.github.io/CsvHelper/getting-started/
        private IEnumerable<CameraRow> getData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
                Delimiter = ";"
            };
            // cheated a bit with the path 🙈
            using (var reader = new StreamReader("../Data/data/cameras-defb.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                // Linq on get records will load everything in memory
                // if it would be on a BIG csv file maybe not the best solution
                return csv.GetRecords<CameraRow>().ToList();
            }
        }
    }
}