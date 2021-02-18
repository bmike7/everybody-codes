using System;
using System.Linq;
using Data;

namespace CameraCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skip over first arg -> name/path of program
            foreach (string arg in args.Skip(1))
                Console.WriteLine(arg);

            CameraData data = new CameraData();
            foreach (CameraRow camaraRow in data.GetData())
            {
                camaraRow.Print();
            }
        }
    }
}