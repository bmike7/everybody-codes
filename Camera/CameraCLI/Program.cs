using System;
using Data;

namespace CameraCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            CameraData data = new CameraData();
            /*//Skip over first arg -> name/path of program
            /*foreach (string arg in args.Skip(1))
                Console.WriteLine(arg);#1#
            
            // Because I spend way to long on reading the csv file with CsvHelper,
            // I will retreive the name argument in an ugly way
            // ==> I will skip the program/path and the flag arg
            // So the program has to be run with the search name in the third position*/
            try
            {
                string searchName = args[2];
            
                foreach (CameraRow camaraRow in data.SearchName(searchName))
                    camaraRow.Print();
            }
            catch (Exception _)
            {
                Console.WriteLine("No search name given");
                foreach (CameraRow camaraRow in data.GetData())
                    camaraRow.Print();
            }
        }
    }
}