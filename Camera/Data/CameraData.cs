using System;
using System.Collections.Generic;

namespace Data
{
    public class CameraRow
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Name} | {Latitude} | {Longitude}");
        }
    }
    
    public class CameraData: ICamaraData
    {
        public IEnumerable<CameraRow> GetData()
        {
            return new List<CameraRow>()
            {
                new CameraRow() {Name = "test", Latitude = 4.323, Longitude = 8.44 }
            };
        }

        public IEnumerable<CameraRow> SearchName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}