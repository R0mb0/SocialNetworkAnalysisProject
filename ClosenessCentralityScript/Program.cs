using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace CentralityScript
{
    class Program
    {
        static void Main(string[] args)
        {
            /* data file path */
            string path = @"C:\Users\tommy\OneDrive\Desktop\data.csv";

            var data = GetData(path);
            Console.WriteLine("Graph centrality is: " + CalculateCentrality(data));
        }

        static double CalculateCentrality(List<int> l)
        {
            int total = 0;
            var max = l.Max();

            foreach (var node in l)
            {
                total += max - node;
            }

            int maxTotal = (max - 1) * (l.Count - 1);
            double centrality = ((double)total / (double)maxTotal);

            return centrality;
        }

        static List<int> GetData(string path)
        {
            var dataList = new List<int>();
            
            using (TextReader r = File.OpenText(path))
            {
                var header = r.ReadLine();
                foreach (string line in File.ReadLines(path))
                {
                    if(line != header)
                        dataList.Add(int.Parse(line));
                }
            }           
            return dataList;
        }
    }
}
