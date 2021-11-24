using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace GraphCentralization
{
    class Program
    {
        static void Main(string[] args)
        {
            /* data file path */
            //string path = @"C:\Users\tommy\OneDrive\Desktop\data.csv"; 

            if (args.Length != 1)
            {
                Console.WriteLine("Usage: GraphCentralization.exe [csv path]");
                Environment.Exit(-1);
            }

            string path = "";
            if (File.Exists(args[0]))
                path = args[0];
            else
            {
                Console.WriteLine("File path not found");
                Environment.Exit(-1);
            }

            var data = GetData(path);
            Console.WriteLine("Graph centralization is: " + CalculateCentralization(data));
        }

        static double CalculateCentralization(List<double> l)
        {
            double total = 0;
            var max = l.Max();

            foreach (var node in l)
            {
                total += max - node;
            }

            double maxTotal = (max - 1) * (l.Count - 1);
            double centralization = total / maxTotal;

            return centralization;
        }

        static List<double> GetData(string path)
        {
            var dataList = new List<double>();

            using (TextReader r = File.OpenText(path))
            {
                var header = r.ReadLine();
                foreach (string line in File.ReadLines(path))
                {
                    if (line != header)
                        dataList.Add(double.Parse(line));
                }
            }
            return dataList;
        }
    }
}
